using LendFoundry.Foundation.Date;
using LendFoundry.Foundation.Logging;
using LendFoundry.Foundation.Persistence.Mongo;
using LendFoundry.Foundation.Services;
using LendFoundry.Security.Tokens;
using LendFoundry.Tenant.Client;
using LendFoundry.Security.Identity.Client;
using Message.Api;
using Message.Repository;
using Message.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Message
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddTenantTime();
            services.AddTokenHandler();
            services.AddHttpServiceLogging(Settings.ServiceName);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTenantService(Settings.Tenant.Host, Settings.Tenant.Port);

            services.AddIdentityService(Settings.Identity.Host, Settings.Identity.Port);

            services.AddMvc().AddLendFoundryJsonOptions();

            services.AddTransient<IMessageService, MessageService>();

            services.AddSingleton<IMongoConfiguration>(
                p => new MongoConfiguration(Settings.MongoConnectionString, Settings.MongoDatabase));
            services.AddTransient<IMessageRepository, MessageMongoRepository>();

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info {
                        Title = "Message API",
                        Version = "v1"
                    });
                }

            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Message API v1");
            });


            app.UseCors(env);
            app.UseErrorHandling();
            
            // PLEASE DO NOT USE THE CODE BELOW TILL WE FINISH THE DC/OS DEPLOY
            //if (!env.IsDevelopment())
            //    app.UseSecurityControl();
            app.UseRequestLogging();
            app.UseHealthCheck();

            app.UseMvc();
            
        }
    }
}
