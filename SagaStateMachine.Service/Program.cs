using MassTransit;
using Microsoft.EntityFrameworkCore;
using SagaStateMachine.Service;
using SagaStateMachine.Service.Instruments;
using SagaStateMachine.Service.StateMachines;
using Shared;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();

        services.AddMassTransit(configure =>
        {
            configure.AddSagaStateMachine<OrderStateMachine, OrderStateInstance>()
              .EntityFrameworkRepository(options =>
              {
                  options.AddDbContext<DbContext, OrderStateDbContext>((provider, builder) =>
                  {
                      builder.UseSqlServer(hostContext.Configuration.GetConnectionString("SQLServer"));
                  });
              });

            configure.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(hostContext.Configuration.GetConnectionString("RabbitMQ"));

                cfg.ReceiveEndpoint(RabbitMQSettings.StateMachine, e =>
                e.ConfigureSaga<OrderStateInstance>(provider));
            }));
        });

    })
    .Build();

await host.RunAsync();
