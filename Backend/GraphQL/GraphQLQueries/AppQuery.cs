using Simple.GraphQL.Backend.Contracts;
using Simple.GraphQL.Backend.GraphQL.GraphQLTypes;
using GraphQL.Types;

namespace Simple.GraphQL.Backend.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
            Field<ListGraphType<OwnerType>>(
               "owners",
               resolve: context => repository.GetAll()
           );
        }
    }
}