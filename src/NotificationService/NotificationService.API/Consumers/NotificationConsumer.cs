using DreamGetter.Shared.Models;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using NotificationService.API.Hubs;

namespace NotificationService.Infrastructure.Consumers
{

    public class NotificationConsumer(IHubContext<NotificationsHub> hubContext, ILogger<NotificationConsumer> logger) : IConsumer<UserNotification>
    {
        public async Task Consume(ConsumeContext<UserNotification> context)
        {
            var notification = context.Message;
            logger.LogInformation(notification.Message);
            await hubContext.Clients.All
                             .SendAsync("ReceiveNotification", new
                             {
                                 notification.EventId,
                                 notification.Message
                             });
        }
    }

}
