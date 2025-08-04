// <copyright file="UpdateAccountCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Application.Commands
{
    using BankingApp.Application.Events;
    using BankingApp.Core.Entities;
    using BankingApp.Core.Interfaces;
    using MediatR;
    using Moq;

    /// <summary>
    /// Command to update a bank account.
    /// </summary>
    /// <param name="accountId">The ID of the account to update.</param>
    /// <param name="account">The updated account information.</param>
    public record UpdateAccountCommand(string accountId, BankAccount account): IRequest<BankAccount>;

    /// <summary>
    /// Handles the update of a bank account.
    /// </summary>
    /// <param name="repository">The bank account repository.</param>
    /// <param name="mediator">The event publisher.</param>
    public class UpdateBankAccountHandler : IRequestHandler<UpdateAccountCommand, BankAccount>
    {
        private readonly IBankAccountRepository repository;
        private readonly IPublisher mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBankAccountHandler"/> class.
        /// </summary>
        /// <param name="repository">The bank account repository.</param>
        /// <param name="mediator">The event publisher.</param>
        public UpdateBankAccountHandler(IBankAccountRepository repository, IPublisher mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBankAccountHandler"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public UpdateBankAccountHandler(IBankAccountRepository repository)
        {
            this.repository = repository;
            this.mediator = new Mock<IPublisher>().Object; // Or use a default implementation
        }


        /// <summary>
        /// Handles the update account command.
        /// </summary>
        /// <param name="request">The update account command.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The updated bank account.</returns>
        public async Task<BankAccount> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await this.repository.UpdateAccount(request.accountId, request.account);
            if (account == null)
            {
                throw new NotFoundException($"Bank account with AccountId : {request.accountId} not found.");
            }

            await this.mediator.Publish(new UpdateAccountEvent(account.AccountId), cancellationToken);
            return account;
        }
    }
}
