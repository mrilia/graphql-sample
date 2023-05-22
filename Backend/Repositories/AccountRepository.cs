using Simple.GraphQL.Backend.Contracts;
using Simple.GraphQL.Backend.Models;
using Simple.GraphQL.Backend.Models.Context;

namespace Simple.GraphQL.Backend.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId) => _context.Accounts
        .Where(a => a.OwnerId.Equals(ownerId))
        .ToList();
    }
}