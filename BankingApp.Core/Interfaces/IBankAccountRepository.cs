// <copyright file="IBankAccountRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Core.Interfaces
{
    using BankingApp.Core.Entities;

    /// <summary>
    /// Defines methods for accessing and manipulating bank account data.
    /// </summary>
    public interface IBankAccountRepository
    {
        /// <summary>
        /// Retrieves all bank accounts of the specified type.
        /// </summary>
        /// <param name="type">The type of bank account to retrieve.</param>
        /// <returns>An enumerable collection of <see cref="BankAccount"/> objects.</returns>
        IEnumerable<BankAccount> GetByType(string type);

        /// <summary>
        /// Retrieves a bank account by its unique account ID.
        /// </summary>
        /// <param name="accountId">The unique identifier of the bank account.</param>
        /// <returns>The <see cref="BankAccount"/> with the specified account ID, or null if not found.</returns>
        BankAccount GetById(string accountId);

        /// <summary>
        /// Updates the details of a bank account.
        /// </summary>
        /// <param name="accountId">The unique identifier of the bank account to update.</param>
        /// <param name="entity">The updated <see cref="BankAccount"/> entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="BankAccount"/>.</returns>
        Task<BankAccount> UpdateAccount(string accountId, BankAccount entity);
    }
}

// This interface defines methods for a bank account repository, including getting accounts by type, getting an account by ID, and updating an account.