using Xunit;
using BankingApp.Core.Entities;

namespace BankingApp.UnitTest;

public class DomainLayerTests
{
    [Fact]
    public void BankAccount_Creation_ShouldSetProperties()
    {
        var account = new BankAccount
        {
            Id = Guid.NewGuid(),
            AccountHolder = "Test User",
            AccountType = "savings",
            Balance = 5000
        };

        Assert.Equal("Test User", account.AccountHolder);
        Assert.Equal("savings", account.AccountType);
        Assert.Equal(5000, account.Balance);
    }
}

