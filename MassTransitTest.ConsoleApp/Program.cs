using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using System.Reflection;

namespace MassTransitTest.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        //x.AddConsumers(typeof(Program).Assembly);
                        x.AddConsumer<SomethingHappenedEventLogger>();
                        x.AddConsumer<SomethingHappenedEventMailer>();
                        x.SetKebabCaseEndpointNameFormatter();

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.ConfigureEndpoints(context);
                        });
                    });

                    services.AddMassTransitHostedService();
                });
    }
}
