using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace NotificationService.API.Hubs;

public class NotificationsHub(ILogger<NotificationsHub> logger) : Hub
{
    public override async Task OnConnectedAsync()
    {
        logger.LogInformation("ConnectedUser: {id}", Context.ConnectionId);

        await base.OnConnectedAsync();
    }
}

