using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.UserService.Business.RabbitMq.Senders;

namespace SkydivingCRM.UserService.Api.Extensions
{
    public static class RabbitMqSendersExtensions
    {
        public static void AddRabbitMqSenders(this IServiceCollection services)
        {
            services.AddSingleton<SkydivingClubAdministratorCreatedSender>();
        }
    }
}