using Simple.GraphQL.Backend.Models;
using GraphQL.Types;
using Simple.GraphQL.Backend.Contracts;
using GraphQL.DataLoader;

namespace Simple.GraphQL.Backend.GraphQL.GraphQLTypes
{
    public class OwnerInputType : InputObjectGraphType
    {
        public OwnerInputType()
        {
            Name = "ownerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("address");
        }
    }
}