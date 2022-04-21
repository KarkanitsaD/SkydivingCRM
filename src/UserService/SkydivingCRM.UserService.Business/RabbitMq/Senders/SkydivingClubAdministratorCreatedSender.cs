using System;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using SkydivingCRM.UserService.Business.RabbitMq.Events.Send;

namespace SkydivingCRM.UserService.Business.RabbitMq.Senders
{
    public class SkydivingClubAdministratorCreatedSender : Sender
    {
        public SkydivingClubAdministratorCreatedSender(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void Send(SkydivingClubAdministratorCreatedEvent ev)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(ConnectionString) };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: RabbitMqQueues.SkydivingClubAdministratorCreatedQueue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(ev));

            channel.BasicPublish(exchange: "",
                                 routingKey: RabbitMqQueues.SkydivingClubAdministratorCreatedQueue,
                                 basicProperties: null,
                                 body: body);
        }
    }
}