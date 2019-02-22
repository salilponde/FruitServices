using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fruits.Gateway.Process
{
    class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot();

            services.AddCors(setup =>
            {
                setup.AddPolicy("DevelopmentPolicy", configure => { configure.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("DevelopmentPolicy");
            }

            app.Use((context, next) =>
            {
                // In real world reverse proxy will set X-Forwarded-Proto and X-Forwarded-Host.
                // But when we run this locally without reverse proxy the below code will
                // set the headers.
                if (!context.Request.Headers.ContainsKey("X-Forwarded-Proto"))
                {
                    context.Request.Headers["X-Forwarded-Proto"] = "http";
                }

                if (!context.Request.Headers.ContainsKey("X-Forwarded-Host"))
                {
                    context.Request.Headers["X-Forwarded-Host"] = "localhost:4000";
                }

                return next();
            });

            app.UseOcelot().Wait();
        }
    }
}
