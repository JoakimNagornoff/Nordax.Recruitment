using Nordax.Bank.Recruitment.Domain.Interfaces.Commands;
using Nordax.Bank.Recruitment.Domain.Interfaces.Repositories;

namespace Nordax.Bank.Recruitment.Logic.Commands;

public class SubscriptionCommands : ISubscriptionCommands
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionCommands(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<Guid> RegisterSubscriptionAsync(string name, string emailAddress)
    {
        var subscriberId = await _subscriptionRepository.RegisterSubscriptionAsync(name, emailAddress);
        return subscriberId;
    }

    public async Task DeleteSubscriberAsync(Guid subscriberId)
    {
        await _subscriptionRepository.DeleteSubscription(subscriberId);
    }
}