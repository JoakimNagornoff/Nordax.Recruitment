using System.Threading.Tasks;
using System;

namespace Nordax.Bank.Recruitment.Domain.Interfaces.Commands;

public interface ISubscriptionCommands
{
    Task<Guid> RegisterSubscriptionAsync(string name, string emailAddress);
    Task DeleteSubscriberAsync(Guid subscriberId);
}