using System;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using SkydivingCRM.SkydivingClubService.Business.RabbitMq.Events.Send;

namespace SkydivingCRM.SkydivingClubService.Business.RabbitMq.Senders
{
    public class SkydivingClubCreatedSender : Sender
    {
        public SkydivingClubCreatedSender(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void Send(SkydivingClubCreatedEvent ev)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(ConnectionString) };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: RabbitMqQueues.SkydivingClubCreatedQueue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(ev));

            channel.BasicPublish(exchange: "",
                                 routingKey: RabbitMqQueues.SkydivingClubCreatedQueue,
                                 basicProperties: null,
                                 body: body);
        }
    }
}