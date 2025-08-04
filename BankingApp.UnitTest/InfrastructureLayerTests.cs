using BankingApp.Application.Commands;
using BankingApp.Application.Queries;
using BankingApp.Infrastructure.Repositories;

namespace BankingApp.UnitTest
{
    public class InfrastructureLayerTests
    {
        private readonly BankAccountRepository _repo = new();

        [Fact]
        public async Task ReturnsAccountsOfSpecifiedType()
        {
            var repo = new BankAccountRepository();
            var handler = new GetAccountsByTypeHandler(repo);

            var result = await handler.Handle(new GetAccountsByTypeQuery("savings"), default);

            Assert.All(result, a => Assert.Equal("savings", a.AccountType, ignoreCase: true));
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectAccount()
        {
            var repo = new BankAccountRepository();
            var sample = repo.GetByType("savings").First();
            var handler = new GetAccountByIdHandler(repo);

            var result = await handler.Handle(new GetAccountByIdQuery(sample.AccountId), default);

            Assert.Equal(sample.Id, result?.Id);
        }

        [Fact]
        public async Task UpdatesAccountSuccessfully()
        {
            var repo = new BankAccountRepository();
            var sample = repo.GetByType("savings").First();
            sample.Balance += 500;

            var handler = new UpdateBankAccountHandler(repo);
            await handler.Handle(new UpdateAccountCommand(sample.AccountId, sample), default);

            var updated = repo.GetById(sample.AccountId);
            Assert.Equal(sample.Balance, updated?.Balance);
        }
    }
}





