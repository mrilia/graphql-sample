using Simple.GraphQL.Backend.Contracts;
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
    }
}