using BankingApp.Application.Queries;
using BankingApp.Infrastructure.Repositories;

namespace BankingApp.UnitTest.ApplicationLayerTests
{
    public class GetAccountByIdHandlerTests
    {
        [Fact]
        public async Task ReturnsCorrectAccount()
        {
            var repo = new BankAccountRepository();
            var sample = repo.GetByType("savings").First();
            var handler = new GetAccountByIdHandler(repo);

            var result = await handler.Handle(new GetAccountByIdQuery(sample.AccountId), default);

            Assert.Equal(sample.Id, result?.Id);
        }
    }

}
