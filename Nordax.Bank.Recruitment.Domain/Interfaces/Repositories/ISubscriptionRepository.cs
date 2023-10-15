using Nordax.Bank.Recruitment.Domain.Models;
using System.Threading.Tasks;
using System;

namespace Nordax.Bank.Recruitment.Domain.Interfaces.Repositories;

public interface ISubscriptionRepository
{
    Task<Guid> RegisterSubscriptionAsync(string firstName, string email);
    Task<SubscriberModel> GetSubscription(Guid subscriberId);
    Task DeleteSubscription(Guid subscriberId);
}