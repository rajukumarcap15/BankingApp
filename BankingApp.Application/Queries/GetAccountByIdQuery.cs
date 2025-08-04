namespace BankingApp.Application.Queries
{
    using BankingApp.Core.Entities;
    using BankingApp.Core.Interfaces;
    using MediatR;

    /// <summary>
    /// Query to retrieve a bank account by its identifier.
    /// </summary>
    public record GetAccountByIdQuery(string id) : IRequest<BankAccount>;

    /// <summary>
    /// Handles the retrieval of a bank account by its identifier.
    /// </summary>
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, BankAccount>
    {
        private readonly IBankAccountRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccountByIdHandler"/> class.
        /// </summary>
        /// <param name="repository">The bank account repository.</param>
        public GetAccountByIdHandler(IBankAccountRepository repository) => this.repository = repository;

        /// <summary>
        /// Handles the specified request to get a bank account by ID.
        /// </summary>
        /// <param name="request">The query containing the account ID.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>The bank account matching the specified ID.</returns>
        public Task<BankAccount> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(this.repository.GetById(request.id));
    }
}
