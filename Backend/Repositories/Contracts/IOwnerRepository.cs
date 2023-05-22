using Simple.GraphQL.Backend.Models;

namespace Simple.GraphQL.Backend.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
    }
}