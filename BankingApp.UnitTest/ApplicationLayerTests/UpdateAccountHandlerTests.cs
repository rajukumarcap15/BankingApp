using BankingApp.Application.Commands;
using BankingApp.Infrastructure.Repositories;
using MediatR;

namespace BankingApp.UnitTest.ApplicationLayerTests
{
    public class UpdateAccountHandlerTests
    {
        [Fact]
        public async Task UpdatesAccountSuccessfully()
        {
            var repo = new BankAccountRepository();
            var sample = repo.GetByType("savings").First();
            sample.Balance += 500;

            var handler = new UpdateBankAccountHandler(repo);
            await handler.Handle(new UpdateAccountCommand(sample.AccountId,sample), default);

            var updated = repo.GetById(sample.AccountId);
            Assert.Equal(sample.Balance, updated?.Balance);
        }
    }   
}
