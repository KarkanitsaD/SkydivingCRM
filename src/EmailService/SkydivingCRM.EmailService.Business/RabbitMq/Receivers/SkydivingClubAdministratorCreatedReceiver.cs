using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;
using SkydivingCRM.EmailService.Business.Models;
using SkydivingCRM.EmailService.Business.RabbitMq.Events.Receive;
using SkydivingCRM.EmailService.Business.Services.IServices;

namespace SkydivingCRM.EmailService.Business.RabbitMq.Receivers
{
    public class SkydivingClubAdministratorCreatedReceiver : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IModel _channel;

        public SkydivingClubAdministratorCreatedReceiver(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;

            var factory = new ConnectionFactory() { Uri = new Uri(configuration.GetConnectionString("RabbitMqConnection")) };
            var connection = factory.CreateConnection();

            _channel = connection.CreateModel();
            _channel.QueueDeclare(
                queue: RabbitMqQueues.SkydivingClubAdministratorCreatedQueue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += Consumer_Received;

            _channel.BasicConsume(
                queue: RabbitMqQueues.SkydivingClubAdministratorCreatedQueue,
                autoAck: true,
                consumer: consumer);

            return Task.CompletedTask;
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var scope = _serviceScopeFactory.CreateScope();

            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

            var skydivingClubAdministratorCreatedEventString = Encoding.UTF8.GetString(e.Body.ToArray());

            var skydivingClubAdministratorCreatedEvent =
                JsonSerializer.Deserialize<SkydivingClubAdministratorCreatedEvent>(
                    skydivingClubAdministratorCreatedEventString);

            var message = new Message(new List<string> {skydivingClubAdministratorCreatedEvent.Email},
                "Email confirmation", GetEmailBody(skydivingClubAdministratorCreatedEvent));

            emailService.Send(message);
        }

        private string GetEmailBody(SkydivingClubAdministratorCreatedEvent ev)
        {
            var body = new StringBuilder($"<h2>Hello dear {ev.Name} {ev.Surname}!</h2>");
            body.Append($"Please <a href=\"https://localhost:5001/api/auth/confirmEmail?code={ev.EmailConfirmationCode}&userId={ev.Id}\">CONFIRM EMAIL!</a>");
            return body.ToString();
        }
    }
}