// <copyright file="UpdateBankAccountDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Core.Dtos
{
    public class UpdateBankAccountDto
    {
        public string AccountId { get; set; } = string.Empty;

        public string AccountHolder { get; set; } = string.Empty;

        public string AccountType { get; set; } = string.Empty;

        public decimal Balance { get; set; }
    }
}

// <summary>