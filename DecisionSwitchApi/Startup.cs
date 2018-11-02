using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Decision.Api.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pivotal.Discovery.Client;
using Pivotal.Extensions.Configuration.ConfigServer;
using Steeltoe.CloudFoundry.Connector;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using Swashbuckle.AspNetCore.Swagger;

namespace Decision.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IContainer Container { get; private set; } = new ContainerBuilder().Build();

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddOptions();
            services.AddCors();

            if (Configuration.HasCloudFoundryServiceConfigurations())
            {
                services.AddConfiguration(Configuration);
                services.AddDiscoveryClient(this.Configuration);
                services.ConfigureCloudFoundryOptions(Configuration);
            }

            services.AddMediatR();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "Decision Switch API", Version = "v1"});
            });

            return new AutofacServiceProvider(Container = services.BuildAutofaContainer());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Decision Switch API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseCors(
                options => options.WithOrigins("http://localhost:54339/").AllowAnyMethod()
            );

            app.UseMvc();

            if (configuration.HasCloudFoundryServiceConfigurations())
            {
                app.UseDiscoveryClient();
            }
        }
    }
}