using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SkydivingCRM.UserService.Business.RabbitMq.Events.Receive;
using SkydivingCRM.UserService.Business.Services.IServices;
using SkydivingCRM.UserService.Data.Entities;

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
            var scope = _serviceScopeFactory.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserEntity>>();

            var skydivingClubCreatedEventString = Encoding.UTF8.GetString(e.Body.ToArray());
            Console.WriteLine(skydivingClubCreatedEventString);
            var skydivingClubCreatedEvent = JsonSerializer.Deserialize<SkydivingClubCreatedEvent>(skydivingClubCreatedEventString);

            if (skydivingClubCreatedEvent is null)
            {
                throw new Exception();
            }


            var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
            await authService.RegisterClubAdministrator(skydivingClubCreatedEvent.User, skydivingClubCreatedEvent.Password);

            var user = await userManager.FindByEmailAsync(skydivingClubCreatedEvent.User.Email);
            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

            /*var skydivingClubAdministratorCreatedSender =
                scope.ServiceProvider.GetRequiredService<SkydivingClubAdministratorCreatedSender>();
            var ev = new SkydivingClubAdministratorCreatedEvent
            {
                Id = user.Id,
                EmailConfirmationCode = code,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };

            skydivingClubAdministratorCreatedSender.Send(ev);*/
        }
    }
}


/*var callbackUrl =
                $"https://localhost:6001/api/skydivingClub/auth/confirmEmail?code={code}&userId={user.Id}";
            await emailService.SendEmailAsync(user.Email, "Email confirmation", $"Confirm email <a href='{callbackUrl}'>Confirm</a>");*/