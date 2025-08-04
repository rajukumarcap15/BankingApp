using BankingApp.Infrastructure.Repositories;

namespace BankingApp.UnitTest
{
    public class InfrastructureLayerTests
    {
        private readonly BankAccountRepository _repo = new();

        [Fact]
        public void GetAll_ShouldReturnAccounts()
        {
            var accounts = _repo.GetAll();
            Assert.NotEmpty(accounts);
        }

        [Fact]
        public void GetById_ShouldReturnCorrectAccount()
        {
            var account = _repo.GetAll().First();
            var result = _repo.GetById(account.Id);
            Assert.Equal(account.Id, result.Id);
        }

        [Fact]
        public void Update_ShouldModifyAccount()
        {
            var account = _repo.GetAll().First();
            var updated = _repo.Update(account.Id, "Updated Name", 9999);

            Assert.Equal("Updated Name", updated.AccountHolder);
            Assert.Equal(9999, updated.Balance);
        }
    }
}





