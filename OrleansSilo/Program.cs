using DataAccessLayer;
using DataDomainLayer.Entity;
using Orleans.Hosting;
using Orleans;
using Orleans.Configuration;
using Microsoft.Extensions.Logging;
using System;
using OrleansGrainInterfaces;
using OrleansGrains;
using System.Net;

namespace OrleansSilo
{
    class Program
    {
        static void Main(string[] args)
        {
            var siloBuilder = new SiloHostBuilder()
                .UseLocalhostClustering(serviceId: "clusterService1")
                .ConfigureLogging(logging => logging.AddConsole())
                .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
                .AddMemoryGrainStorage("OrleansMemoryStorage")
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(OrderOperation).Assembly).WithReferences())
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(InsertOperation).Assembly).WithReferences())
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(GetOperation).Assembly).WithReferences())
                .UseDashboard(options => { });
                
            var host = siloBuilder.Build();
            host.StartAsync();
            Console.ReadLine();
            host.StopAsync();
        }
    }
}
