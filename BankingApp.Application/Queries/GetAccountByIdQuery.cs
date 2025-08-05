// <copyright file="GetAccountByIdQuery.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Application.Queries
{
    using BankingApp.Core.Entities;
    using BankingApp.Core.Interfaces;
    using MediatR;

    /// <summary>
    /// Query to retrieve a bank account by its identifier.
    /// </summary>
    public record GetAccountByIdQuery(string Id) : IRequest<BankAccount>;

    /// <summary>
    /// Handles the retrieval of a bank account by its identifier.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="GetAccountByIdHandler"/> class.
    /// </remarks>
    /// <param name="repository">The bank account repository.</param>
    public class GetAccountByIdHandler(IBankAccountRepository repository): IRequestHandler<GetAccountByIdQuery, BankAccount>
    {
        /// <summary>
        /// Handles the specified request to get a bank account by ID.
        /// </summary>
        /// <param name="request">The query containing the account ID.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The bank account matching the specified ID.</returns>
        public Task<BankAccount> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(repository.GetById(request.Id));
    }
}
