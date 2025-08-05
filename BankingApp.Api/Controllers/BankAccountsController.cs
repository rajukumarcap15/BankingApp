// <copyright file="BankAccountsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Api.Controllers
{
    using BankingApp.Application.Commands;
    using BankingApp.Application.Queries;
    using BankingApp.Core.Dtos;
    using FluentResults;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Identity.Client;

    /// <summary>
    /// Controller for managing bank accounts.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        /// <summary>
        /// Gets the mediator instance used for sending commands and queries.
        /// </summary>
        public IMediator Mediator { get; }
        private readonly ILogger<BankAccountsController> _logger;

        public BankAccountsController(IMediator mediator, ILogger<BankAccountsController> logger)
        {
            Mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Gets bank accounts by type.
        /// </summary>
        /// <param name="type">The type of bank account.</param>
        /// <returns>A list of bank accounts matching the specified type.</returns>
        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetByType(string type)
        {
            _logger.LogInformation("Received request to get accounts of type: {Type}", type);
            var result = await this.Mediator.Send(new GetAccountsByTypeQuery(type));
            _logger.LogInformation("Returning {Count} accounts of type {Type}", result.Count(), type);
            return this.Ok(result);
        }

        /// <summary>
        /// Gets a bank account by its account ID.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <returns>The bank account with the specified ID, or NotFound if not found.</returns>
        [HttpGet("accountId/{accountId}")]
        public async Task<IActionResult> GetById(string accountId)
        {
            _logger.LogInformation("Received request to get account with AccountId: {AccountId}", accountId);
            var account = await this.Mediator.Send(new GetAccountByIdQuery(accountId));
            if (account == null)
            {
                _logger.LogWarning("Account with AccountId {AccountId} not found", accountId);
                return this.NotFound();
            }
            _logger.LogInformation("Returning account with AccountId {AccountId}", accountId);
            return this.Ok(account);
        }

        /// <summary>
        /// Updates a bank account.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="updatedAccount">The updated bank account information.</param>
        /// <returns>The updated bank account.</returns>
        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdateAccount(string accountId, [FromBody] UpdateBankAccountDto updatedAccount)
        {
            _logger.LogInformation("Received request to update account with AccountId: {AccountId}", accountId);
            var result = await this.Mediator.Send(new UpdateAccountCommand(accountId, updatedAccount));

            if (result != null)
            {
                _logger.LogInformation("Successfully updated account with AccountId {AccountId}", accountId);
                return this.Ok(result);
            }

            _logger.LogWarning("Update failed: Account with AccountId {AccountId} not found", accountId);
            return NotFound();
        }
    }
}
