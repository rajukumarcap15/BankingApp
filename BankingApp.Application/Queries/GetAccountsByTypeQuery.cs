// <copyright file="GetAccountsByTypeQuery.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BankingApp.Application.Queries
{
    using BankingApp.Core.Entities;
    using BankingApp.Core.Interfaces;
    using MediatR;

    /// <summary>
    /// Query to retrieve bank accounts by their type.
    /// </summary>
    public record GetAccountsByTypeQuery(string Accounttype): IRequest<IEnumerable<BankAccount>>;

    /// <summary>
    /// Handles the <see cref="GetAccountsByTypeQuery"/> to return bank accounts of a specified type.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="GetAccountsByTypeHandler"/> class.
    /// </remarks>
    /// <param name="repository">The bank account repository.</param>
    public class GetAccountsByTypeHandler(IBankAccountRepository repository) : IRequestHandler<GetAccountsByTypeQuery, IEnumerable<BankAccount>>
    {
        /// <summary>
        /// Handles the query to get bank accounts by type.
        /// </summary>
        /// <param name="request">The query request containing the account type.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A collection of <see cref="BankAccount"/> objects matching the specified type.</returns>
        public Task<IEnumerable<BankAccount>> Handle(GetAccountsByTypeQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(repository.GetByType(request.Accounttype));
    }
}

// This code defines a query to get bank accounts by their type.