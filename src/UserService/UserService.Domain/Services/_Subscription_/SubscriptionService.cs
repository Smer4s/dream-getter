using DreamGetter.Shared.Abstractions.Repositories;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.Abstractions.Services;
using UserService.Domain.Services._User_;

namespace UserService.Domain.Services._Subscription_;

internal class SubscriptionService(IUserRepository userRepository, IUnitOfWork unitOfWork) : ISubscriptionService
{
    public async Task AddSubscription(Guid subscriberId, Guid subscribeToId)
    {
        var subscriber = await userRepository.GetById(subscriberId);
        if (subscriber == null)
        {
            throw new ArgumentException();
        }

        var subscribeOn = await userRepository.GetById(subscribeToId);
        if (subscribeOn == null)
        {
            throw new ArgumentException();
        }

        if (subscriber.SubscribedOn.Any(x => x.Id == subscribeToId))
        {
            throw new ArgumentException();
        }

        subscriber.SubscribedOn.Add(subscribeOn);

        await unitOfWork.SaveChangesAsync();
    }
}
