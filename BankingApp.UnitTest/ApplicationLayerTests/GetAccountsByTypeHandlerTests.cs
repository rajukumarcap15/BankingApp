using BankingApp.Application.Queries;
using BankingApp.Infrastructure.Repositories;

namespace BankingApp.UnitTest.ApplicationLayerTests
{
    public class GetAccountsByTypeHandlerTests
    {
        [Fact]
        public async Task ReturnsAccountsOfSpecifiedType()
        {
            var repo = new BankAccountRepository();
            var handler = new GetAccountsByTypeHandler(repo);

            var result = await handler.Handle(new GetAccountsByTypeQuery("savings"), default);

            Assert.All(result, a => Assert.Equal("savings", a.AccountType, ignoreCase: true));
        }
    }
}