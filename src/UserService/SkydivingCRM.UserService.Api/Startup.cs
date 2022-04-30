using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.UserService.Api.Extensions;
using SkydivingCRM.UserService.Business.Options;
using SkydivingCRM.UserService.Business.RabbitMq.Receivers;
using SkydivingCRM.UserService.Data;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Api
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
            

            services.AddDbContext<UserServiceContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<UserEntity, RoleEntity>()
                .AddEntityFrameworkStores<UserServiceContext>()
                .AddDefaultTokenProviders();


            services.AddJwtOptions(Configuration);

            services.AddMappingProfiles();

            services.AddJwtBearerAuthentication(Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>());
            services.AddAuthorizationHandlers();
            services.AddAuthorizationService();

            services.AddRabbitMqSenders();

            services.AddRepositories();
            services.AddServices();
            services.AddControllers();

            services.AddHostedService<SkydivingClubCreatedReceiver>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SkydivingCRM.UserService.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkydivingCRM.UserService.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
