// <copyright file="BankAccountsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Api.Controllers
{
    using BankingApp.Application.Commands;
    using BankingApp.Application.Queries;
    using BankingApp.Core.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for managing bank accounts.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Gets bank accounts by type.
        /// </summary>
        /// <param name="type">The type of bank account.</param>
        /// <returns>A list of bank accounts matching the specified type.</returns>
        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetByType(string type)
        {
            var accounts = await mediator.Send(new GetAccountsByTypeQuery(type));
            return this.Ok(accounts);
        }

        /// <summary>
        /// Gets a bank account by its account ID.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <returns>The bank account with the specified ID, or NotFound if not found.</returns>
        [HttpGet("accountId/{accountId}")]
        public async Task<IActionResult> GetById(string accountId)
        {
            var account = await mediator.Send(new GetAccountByIdQuery(accountId));
            if (account == null)
            {
                return this.NotFound();
            }

            return this.Ok(account);
        }

        /// <summary>
        /// Updates a bank account.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="updatedAccount">The updated bank account information.</param>
        /// <returns>The updated bank account.</returns>
        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdateAccount(string accountId, [FromBody] BankAccount updatedAccount)
        {
            var result = await mediator.Send(new UpdateAccountCommand(accountId, updatedAccount));
            return this.Ok(result);
        }
    }
}
