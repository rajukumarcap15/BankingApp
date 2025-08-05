using BankingApp.Application.Commands;
using BankingApp.Core.Dtos;
using BankingApp.Infrastructure.Repositories;
using MediatR;
using Moq;

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

            var dto = new UpdateBankAccountDto
            {
                AccountId = sample.AccountId,
                AccountHolder = sample.AccountHolder,
                AccountType = sample.AccountType,
                Balance = sample.Balance
            };

            await handler.Handle(new UpdateAccountCommand(sample.AccountId, dto), default);

            var updated = repo.GetById(sample.AccountId);
            Assert.Equal(sample.Balance, updated?.Balance);
        }
    }
}
