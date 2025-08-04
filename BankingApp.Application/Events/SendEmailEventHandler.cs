// <copyright file="SendEmailEventHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Application.Events
{
    using MediatR;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Handles the event for sending an email when an account is updated.
    /// </summary>
    public class SendEmailEventHandler
     (ILogger<SendEmailEventHandler> logger)
     : INotificationHandler<UpdateAccountEvent>
    {
        /// <summary>
        /// Handles the <see cref="UpdateAccountEvent"/> by simulating sending an email.
        /// </summary>
        /// <param name="notification">The account update event notification.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Handle(UpdateAccountEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Account update: Send mail start for {AccountId}", notification.accountId);

            await Task.Delay(2000, cancellationToken);

            logger.LogInformation("Account update: Send mail done for {AccountId}", notification.accountId);
        }
    }
}
