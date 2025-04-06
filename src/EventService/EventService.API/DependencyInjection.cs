using DreamGetter.Shared.WebInjections;
using MassTransit;

namespace EventService.API;

internal static class DependencyInjection
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddDreamGetterSwagger();

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {                cfg.Host("rabbitmq://localhost:5672", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                }); 
                
            });
        });

        return services;
    }
}

