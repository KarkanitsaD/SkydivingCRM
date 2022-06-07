using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SkydivingCRM.UserService.Api.Extensions;
using SkydivingCRM.UserService.Api.IdentityServer4;
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
            //Auth
            services.AddAuthorizationService();

            //Options
            services.AddOptions(Configuration);

            //Services
            services.AddMappingProfiles();

            services.AddDbContext<UserServiceContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<UserEntity, RoleEntity>()
                .AddEntityFrameworkStores<UserServiceContext>()
                .AddDefaultTokenProviders();

            services.AddRepositories();
            services.AddServices();
            services.AddControllers();

            //IdentityServer4
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Config.ApiResources)
                .AddInMemoryClients(Config.Clients)
                .AddResourceOwnerValidator<UserValidator>();
            services.AddLocalApiAuthentication();


            //RabbitMq
            services.AddHostedService<SkydivingClubCreatedReceiver>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseIdentityServer();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
