using Microsoft.EntityFrameworkCore;
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

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts.Where(a => ownerIds.Contains(a.OwnerId)).ToListAsync();
            return accounts.ToLookup(x => x.OwnerId);
        }
    }
}