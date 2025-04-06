using MassTransit;
using NotificationService.API.Hubs;
using NotificationService.Infrastructure.Consumers;

namespace NotificationService.API;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<NotificationConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost:5672"); 

                cfg.ReceiveEndpoint("user-notification-queue", e =>
                {
                    e.ConfigureConsumer<NotificationConsumer>(context);
                });
            });
        });

        services.AddSignalR(options =>
        {

        }).AddHubOptions<NotificationsHub>(options =>
        {

        });

        return services;
    }
}
