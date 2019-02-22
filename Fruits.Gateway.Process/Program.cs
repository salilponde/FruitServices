using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using System;

namespace Fruits.Gateway.Process
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddOcelot(hostingContext.HostingEnvironment)
                        .AddJsonFile("appsettings.json", true, true);
                })
                .UseStartup<Startup>()
                .UseKestrel((context, options) =>
                {
                    options.Configure(context.Configuration.GetSection("Kestrel"));
                })
                .Build();

            host.Run();
        }
    }
}
