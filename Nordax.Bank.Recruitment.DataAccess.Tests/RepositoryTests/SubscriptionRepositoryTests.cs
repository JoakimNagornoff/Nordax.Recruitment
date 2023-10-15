using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nordax.Bank.Recruitment.DataAccess.Entities;
using Nordax.Bank.Recruitment.DataAccess.Exceptions;
using Nordax.Bank.Recruitment.DataAccess.Repositories;
using Nordax.Bank.Recruitment.DataAccess.Tests.Configuration;

namespace Nordax.Bank.Recruitment.DataAccess.Tests.RepositoryTests
{
    [TestClass]
    public class SubscriptionRepositoryTests
    {
        private readonly SubscriptionRepository _subscriptionRepository = new(EfConfig.CreateInMemoryApplicationDbContext());
        private readonly ApplicationDbContext _testDbContext = EfConfig.CreateInMemoryTestDbContext();

        [TestCleanup]
        public void Cleanup()
        {
            _testDbContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public async Task RegisterSubscriptionAsync_EmailExists_SHouldThrowException()
        {
            await _testDbContext.Subscriptions.AddAsync(new Subscription("firstNAme", "email@email.email"));
            await _testDbContext.SaveChangesAsync();

            await Assert.ThrowsExceptionAsync<EmailAlreadyRegisteredException>(
                () => _subscriptionRepository.RegisterSubscriptionAsync("first", "email@email.email")
            );
        }

        [TestMethod]
        public async Task RegisterSubscriptionAsync_NewEmail_ShouldAddSubscription()
        {
            await _subscriptionRepository.RegisterSubscriptionAsync("first", "email@email.email");

            var subscription = await _testDbContext.Subscriptions.SingleAsync();

            Assert.AreEqual("first", subscription.Name);
            Assert.AreEqual("email@email.email", subscription.Email);
        }
    }
}