// <copyright file="BankAccountRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Infrastructure.Repositories
{
    using Azure.Core;
    using BankingApp.Core.Entities;
    using BankingApp.Core.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository for managing bank account data.
    /// </summary>
    public class BankAccountRepository : IBankAccountRepository
    {
        /// <summary>
        /// Simulates a database with an in-memory list of bank accounts.
        /// </summary>
        private readonly List<BankAccount> accounts =
    [
        new BankAccount { Id = Guid.NewGuid(), AccountId = "CId1", AccountHolder = "Alice Johnson", AccountType = "Savings", Balance = 100 },
        new BankAccount { Id = Guid.NewGuid(), AccountId = "CId2", AccountHolder = "Ravi Kumar", AccountType = "Current", Balance = 200 },
        new BankAccount { Id = Guid.NewGuid(), AccountId = "CId3", AccountHolder = "Carlos Mendoza", AccountType = "Savings", Balance = 300 },
        new BankAccount { Id = Guid.NewGuid(), AccountId = "CId4", AccountHolder = "Priya Desai", AccountType = "Current", Balance = 500 },
        new BankAccount { Id = Guid.NewGuid(), AccountId = "CId5", AccountHolder = "John Smith", AccountType = "Savings", Balance = 1000 },
        new BankAccount { Id = Guid.NewGuid(), AccountId = "CId6", AccountHolder = "David O'Connor", AccountType = "Current", Balance = 500 },
        new BankAccount { Id = Guid.NewGuid(), AccountId = "CId7", AccountHolder = "Isabella Rossi", AccountType = "Savings", Balance = 1000 },
        new BankAccount { Id = Guid.NewGuid(), AccountId = "CId8", AccountHolder = "Liam Murphy", AccountType = "Current", Balance = 7000 },
        new BankAccount { Id = Guid.NewGuid(), AccountId = "CId9", AccountHolder = "Alice", AccountType = "Savings", Balance = 10 },
        new BankAccount { Id = Guid.NewGuid(), AccountId = "CId10", AccountHolder = "Bob", AccountType = "Current", Balance = 800 },
    ];

        /// <summary>
        /// Gets all bank accounts.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IEnumerable<BankAccount>> GetAccounts()
        {
            // Since accounts is an in-memory List, ToListAsync is not available.
            // Use Task.FromResult to simulate async behavior.
            return await Task.FromResult(this.accounts.ToList());
        }


        /// <summary>
        /// Gets all bank accounts of the specified type.
        /// </summary>
        /// <param name="type">The account type to filter by.</param>
        /// <returns>An enumerable of bank accounts matching the type.</returns>
        public IEnumerable<BankAccount> GetByType(string type) =>
            this.accounts.Where(a => a.AccountType.Equals(type, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Gets a bank account by its account ID.
        /// </summary>
        /// <param name="accountId">The account ID to search for.</param>
        /// <returns>The matching bank account, or null if not found.</returns>
        public BankAccount GetById(string accountId)
        {
            return this.accounts.FirstOrDefault(a => a.AccountId == accountId) !;
        }

        /// <summary>
        /// Updates an existing bank account with new data.
        /// </summary>
        /// <param name="accountId">The account ID of the account to update.</param>
        /// <param name="account">The new account data.</param>
        /// <returns>The updated bank account, or null if not found.</returns>
        public async Task<BankAccount> UpdateAccount(string accountId, BankAccount account)
        {
            var existing = this.accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (existing != null)
            {
                existing.AccountId = account.AccountId;
                existing.AccountHolder = account.AccountHolder;
                existing.AccountType = account.AccountType;
                existing.Balance = account.Balance;

                // Simulate async operation
                await Task.CompletedTask;
                return existing;
            }
            else
            {
                // Return null for not found, matching interface signature
                await Task.CompletedTask;
                return null!;
            }
        }
    }
}
