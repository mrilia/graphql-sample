using Simple.GraphQL.Backend.Contracts;
using Simple.GraphQL.Backend.GraphQL.GraphQLTypes;
using GraphQL.Types;
using GraphQL;
using Simple.GraphQL.Backend.Models;

namespace Simple.GraphQL.Backend.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IOwnerRepository repository)
        {
            Field<OwnerType>(
            "createOwner",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" }),
            resolve: context =>
            {
                var owner = context.GetArgument<Owner>("owner");
                return repository.CreateOwner(owner);
            }
        );
        }
    }
}