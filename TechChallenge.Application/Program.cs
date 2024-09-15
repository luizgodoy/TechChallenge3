using System;
using System.Reflection;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using TechChallenge.API.AutoMapper;
using TechChallenge.Application.Consumers;
using TechChallenge.Data.Context;
using TechChallenge.Data.Repository;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.Services;

namespace TechChallenge.Application
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddAutoMapper(typeof(MapperProfile), typeof(MapperProfile));

                    services.AddScoped<IContactService, ContactService>();
                    services.AddScoped<IContactRepository, ContactRepository>();

                    var connectionString = hostContext.Configuration.GetConnectionString("SqlConnection");
                    services.AddDbContext<techchallengeDbContext>(options => options.UseSqlServer(connectionString));
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumers(Assembly.GetEntryAssembly());

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host("localhost", "/", h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                            });

                            const string exchangeName = "tech.challenge.direct";
                            
                            cfg.ReceiveEndpoint("add-contact", e =>
                            {
                                e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                                e.ConfigureConsumeTopology = false;

                                e.Bind(exchangeName, s =>
                                { 
                                    s.RoutingKey = "add.contact";
                                    s.ExchangeType = ExchangeType.Direct;
                                    s.Durable = true;
                                });
                                
                                e.ConfigureConsumer<AddContactConsumer>(context);
                            });
                            
                        
                            cfg.ReceiveEndpoint("update-contact", e =>
                            {
                                e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                                e.ConfigureConsumeTopology = false;

                                e.Bind(exchangeName, s =>
                                {
                                    s.RoutingKey = "update.contact";
                                    s.ExchangeType = ExchangeType.Direct;
                                    s.Durable = true;
                                });
                                
                                e.ConfigureConsumer<EditContactConsumer>(context);
                            });
                            
                 
                            cfg.ReceiveEndpoint("delete-contact", e =>
                            {
                                e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                                e.ConfigureConsumeTopology = false;

                                e.Bind(exchangeName, s =>
                                {
                                    s.RoutingKey = "delete.contact";
                                    s.ExchangeType = ExchangeType.Direct;
                                    s.Durable = true;
                                });
                                
                                e.ConfigureConsumer<DeleteContactConsumer>(context);
                            });
                        });
                    });
                });
    }
}
