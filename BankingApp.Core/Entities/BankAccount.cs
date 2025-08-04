// <copyright file="BankAccount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Core.Entities
{
    /// <summary>
    /// Represents a bank account with basic account information and balance.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Gets or sets the unique identifier for the bank account.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the account ID assigned by the bank.
        /// </summary>
        public string AccountId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the account holder.
        /// </summary>
        public string AccountHolder { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of the account (e.g., "savings" or "current").
        /// </summary>
        public string AccountType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the current balance of the account.
        /// </summary>
        public decimal Balance { get; set; }
    }
}
