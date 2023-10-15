using Nordax.Bank.Recruitment.Domain.Interfaces.Queries;
using Nordax.Bank.Recruitment.Domain.Interfaces.Repositories;
using Nordax.Bank.Recruitment.Domain.Models;

namespace Nordax.Bank.Recruitment.Logic.Queries;

public class SubscriptionQueries : ISubscriptionQueries
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionQueries(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<SubscriberModel> GetSubscriberAsync(Guid subscriberId)
    {
        var subscriber = await _subscriptionRepository.GetSubscription(subscriberId);
        return subscriber;
    }
}