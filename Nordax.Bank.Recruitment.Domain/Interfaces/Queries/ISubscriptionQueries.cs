using System.Threading.Tasks;
using System;
using Nordax.Bank.Recruitment.Domain.Models;

namespace Nordax.Bank.Recruitment.Domain.Interfaces.Queries;

public interface ISubscriptionQueries
{
    Task<SubscriberModel> GetSubscriberAsync(Guid subscriberId);
}