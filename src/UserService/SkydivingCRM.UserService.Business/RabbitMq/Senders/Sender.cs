using Microsoft.Extensions.Configuration;

namespace SkydivingCRM.UserService.Business.RabbitMq.Senders
{
    public class Sender
    {
        protected readonly string ConnectionString;

        public Sender(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("RabbitMqConnection");
        }
    }
}