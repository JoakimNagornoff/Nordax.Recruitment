using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nordax.Bank.Recruitment.Domain.Interfaces.Repositories;
using Nordax.Bank.Recruitment.Logic.Commands;

namespace Nordax.Bank.Recruitment.Logic.Tests.CommandsTests;

[TestClass]
public class SubscriptionCommandsTests
{
    private readonly Mock<ISubscriptionRepository> _subscriptionRepositoryMock;
    private readonly SubscriptionCommands _subscriptionCommands;

    public SubscriptionCommandsTests()
    {
        _subscriptionRepositoryMock = new Mock<ISubscriptionRepository>();
        _subscriptionCommands = new SubscriptionCommands(_subscriptionRepositoryMock.Object);
    }

    [TestMethod]
    public async Task RegisterSubscriptionAsync_NoErrors_VerifyCalls()
    {
        var email = "email@email.email";
        var firstName = "firstName";
        await _subscriptionCommands.RegisterSubscriptionAsync(firstName, email);

        _subscriptionRepositoryMock.Verify(a => a.RegisterSubscriptionAsync(firstName, email));
    }
}