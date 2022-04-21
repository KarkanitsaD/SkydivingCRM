using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkydivingCRM.EmailService.Api.Extensions;
using SkydivingCRM.EmailService.Business.Options;
using SkydivingCRM.EmailService.Business.RabbitMq.Receivers;

namespace SkydivingCRM.EmailService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var emailOptions = Configuration.GetSection(nameof(EmailOptions)).Get<EmailOptions>();
            services.AddSingleton(emailOptions);
            services.AddServices();
            services.AddHostedService<SkydivingClubAdministratorCreatedReceiver>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}