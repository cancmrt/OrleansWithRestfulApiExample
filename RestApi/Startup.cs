using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Orleans;
using Orleans.Configuration;
using Swashbuckle.AspNetCore.Swagger;

namespace RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var orleansClient = OrleansClient();
            services.AddSingleton<IClusterClient>(orleansClient);
            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v0.1", new Info
                {
                    Version = "v0.1",
                    Title = "Orleans With .net core and restful api",
                    Description = "Using Orleans with .netcore with crud operations(entity framework,repository pattern, unit of work pattern,dal)",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Can Cömert",
                        Email = "cancm91@gmail.com"
                    }

                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(swag =>
            {
                swag.SwaggerEndpoint("/swagger/v0.1/swagger.json", "Orleans With .net core and restful api v0.1");
            });
        }
        private IClusterClient OrleansClient()
        {
            var clientBuilder = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "cluster1";
                    options.ServiceId = "clusterService1";
                })
                .ConfigureLogging(logging => logging.AddConsole());
            var client = clientBuilder.Build();
            client.Connect().Wait();
            return client;
        }
    }
}
