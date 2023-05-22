using Simple.GraphQL.Backend.Contracts;
using Simple.GraphQL.Backend.Models;
using Simple.GraphQL.Backend.Models.Context;

namespace Simple.GraphQL.Backend.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AccountContext _context;

        public OwnerRepository(AccountContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll() => _context.Owners.ToList();
    }
}