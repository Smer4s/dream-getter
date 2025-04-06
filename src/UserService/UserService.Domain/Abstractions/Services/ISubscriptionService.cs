namespace UserService.Domain.Abstractions.Services;

public interface ISubscriptionService
{
    Task AddSubscription(Guid subscriberId, Guid subscribeToId);
}
