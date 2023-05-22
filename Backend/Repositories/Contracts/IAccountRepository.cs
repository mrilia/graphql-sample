using Simple.GraphQL.Backend.Models;

namespace Simple.GraphQL.Backend.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId);
    }
}