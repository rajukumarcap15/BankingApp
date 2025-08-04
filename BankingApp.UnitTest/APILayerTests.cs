using BankingApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BankingApp.UnitTest
{
    public class APILayerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public APILayerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetByType_ShouldReturnOk()
        {
            var response = await _client.GetAsync("/api/BankAccounts/type/savings");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetById_ShouldReturnOkOrNotFound()
        {
            var repo = new BankAccountRepository();
            var account = repo.GetByType("savings").First();

            var response = await _client.GetAsync($"/api/BankAccounts/{account.Id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

