// <copyright file="UpdateBankAccountDtoValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace BankingApp.Core.Validators
{
    using BankingApp.Core.Dtos;
    using FluentValidation;

    /// <summary>
    /// Validator for <see cref="UpdateBankAccountDto"/>. Ensures that account holder, account type, and balance are valid.
    /// </summary>
    public class UpdateBankAccountDtoValidator : AbstractValidator<UpdateBankAccountDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBankAccountDtoValidator"/> class.
        /// </summary>
        public UpdateBankAccountDtoValidator()
        {
            this.RuleFor(x => x.AccountHolder)
                .NotEmpty().WithMessage("Account holder name is required.")
                .MaximumLength(100).WithMessage("Account holder name must be less than 100 characters.");

            this.RuleFor(x => x.AccountType)
                .NotEmpty().WithMessage("Account type is required.")
                .Must(type => type == "savings" || type == "current")
                .WithMessage("Account type must be either 'savings' or 'current'.");

            this.RuleFor(x => x.Balance)
                .GreaterThanOrEqualTo(0).WithMessage("Balance cannot be negative.");
        }
    }
}
