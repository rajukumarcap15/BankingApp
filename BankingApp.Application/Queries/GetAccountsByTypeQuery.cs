namespace BankingApp.Application.Queries
{
    using BankingApp.Core.Entities;
    using BankingApp.Core.Interfaces;
    using MediatR;

    /// <summary>
    /// Query to retrieve bank accounts by their type.
    /// </summary>
    public record GetAccountsByTypeQuery(string accountType) : IRequest<IEnumerable<BankAccount>>;

    /// <summary>
    /// Handles the <see cref="GetAccountsByTypeQuery"/> to return bank accounts of a specified type.
    /// </summary>
    public class GetAccountsByTypeHandler : IRequestHandler<GetAccountsByTypeQuery, IEnumerable<BankAccount>>
    {
        private readonly IBankAccountRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountsByTypeHandler"/> class.
        /// </summary>
        /// <param name="repository">The bank account repository.</param>
        public GetAccountsByTypeHandler(IBankAccountRepository repository) => this.repository = repository;

        /// <summary>
        /// Handles the query to get bank accounts by type.
        /// </summary>
        /// <param name="request">The query request containing the account type.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A collection of <see cref="BankAccount"/> objects matching the specified type.</returns>
        public Task<IEnumerable<BankAccount>> Handle(GetAccountsByTypeQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(this.repository.GetByType(request.accountType));
    }
}

// This code defines a query to get bank accounts by their type.