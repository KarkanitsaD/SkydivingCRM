using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.SkydivingClubService.Business.RabbitMq.Senders;

namespace SkydivingCRM.SkydivingClubService.Api.Extensions
{
    public static class RabbitMqExtensions
    {
        public static void AddRabbitMqSenders(this IServiceCollection services)
        {
            services.AddScoped<SkydivingClubCreatedSender>();
        }
    }
}