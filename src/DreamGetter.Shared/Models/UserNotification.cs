namespace DreamGetter.Shared.Models;

public record UserNotification
{
    public Guid SubscriberId { get; init; }
    public Guid EventId { get; init; }
    public string Message { get; init; } = null!;
}