using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SkydivingCRM.UserService.Business.RabbitMq.Events.Receive;
using SkydivingCRM.UserService.Business.Services.IServices;

namespace SkydivingCRM.UserService.Business.RabbitMq.Receivers
{
    public class SkydivingClubCreatedReceiver : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IModel _channel;

        public SkydivingClubCreatedReceiver(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;

            var factory = new ConnectionFactory() { Uri = new Uri(configuration.GetConnectionString("RabbitMqConnection")) };
            var connection = factory.CreateConnection();

            _channel = connection.CreateModel();
            _channel.QueueDeclare(
                queue: RabbitMqQueues.SkydivingClubCreatedQueue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Start");
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += Consumer_Received;

            _channel.BasicConsume(
                queue: RabbitMqQueues.SkydivingClubCreatedQueue,
                autoAck: true,
                consumer: consumer);
            Console.WriteLine("Stop");
            return Task.CompletedTask;
        }

        private async void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var authService = _serviceScopeFactory.CreateScope()
                .ServiceProvider.GetRequiredService<IAuthService>();
            var mapper = _serviceScopeFactory.CreateScope()
                .ServiceProvider.GetRequiredService<IMapper>();

            var skydivingClubCreatedEventString = Encoding.UTF8.GetString(e.Body.ToArray());
            Console.WriteLine(skydivingClubCreatedEventString);
            var skydivingClubCreatedEvent = JsonSerializer.Deserialize<SkydivingClubCreatedEvent>(skydivingClubCreatedEventString);

            if (skydivingClubCreatedEvent is null)
            {
                throw new Exception();
            }

            await authService.RegisterDirector(skydivingClubCreatedEvent.User, skydivingClubCreatedEvent.Password);
        }
    }
}