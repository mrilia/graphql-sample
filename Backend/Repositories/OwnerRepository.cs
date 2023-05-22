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
        public Owner GetById(Guid id) => _context.Owners.SingleOrDefault(o => o.Id.Equals(id));
        public Owner CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _context.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public Owner UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;

            _context.SaveChanges();
            return dbOwner;
        }
    }
}