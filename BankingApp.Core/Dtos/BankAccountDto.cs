// <copyright file="BankAccountDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Core.Dtos
{
    /// <summary>
    /// Data transfer object representing a bank account.
    /// </summary>
    public class BankAccountDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the bank account.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the account ID.
        /// </summary>
        public string AccountId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the account holder.
        /// </summary>
        public string AccountHolder { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the type of the bank account.
        /// </summary>
        public string AccountType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the balance of the bank account.
        /// </summary>
        public decimal Balance { get; set; }
    }
}
