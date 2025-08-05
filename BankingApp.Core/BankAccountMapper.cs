// <copyright file="BankAccountMapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Core
{
    using BankingApp.Core.Dtos;
    using BankingApp.Core.Entities;

    /// <summary>
    /// Provides methods for mapping between <see cref="BankAccount"/> entities and DTOs.
    /// </summary>
    public static class BankAccountMapper
    {
        /// <summary>
        /// Maps a <see cref="BankAccount"/> entity to a <see cref="BankAccountDto"/>.
        /// </summary>
        /// <param name="entity">The <see cref="BankAccount"/> entity to map.</param>
        /// <returns>A <see cref="BankAccountDto"/> representing the entity.</returns>
        public static BankAccountDto ToDto(BankAccount entity)
        {
            return new ()
            {
                Id = entity.Id,
                AccountHolder = entity.AccountHolder,
                AccountType = entity.AccountType,
                Balance = entity.Balance,
            };
        }

        /// <summary>
        /// Maps an <see cref="UpdateBankAccountDto"/> to a <see cref="BankAccount"/> entity.
        /// </summary>
        /// <param name="id">The identifier for the bank account.</param>
        /// <param name="dto">The <see cref="UpdateBankAccountDto"/> containing updated data.</param>
        /// <returns>A <see cref="BankAccount"/> entity with updated values.</returns>
        public static BankAccount ToEntity(Guid id, UpdateBankAccountDto dto)
        {
            return new ()
            {
                Id = id,
                AccountHolder = dto.AccountHolder,
                AccountType = dto.AccountType,
                Balance = dto.Balance,
            };
        }
    }
}
