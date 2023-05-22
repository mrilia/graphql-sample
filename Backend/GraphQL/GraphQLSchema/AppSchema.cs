using Simple.GraphQL.Backend.GraphQL.GraphQLQueries;
using GraphQL.Types;

namespace Simple.GraphQL.Backend.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<AppQuery>();
        }
    }
}