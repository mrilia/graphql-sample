using Simple.GraphQL.Backend.Models;
using GraphQL.Types;
using Simple.GraphQL.Backend.Contracts;
using ASPCoreGraphQL.Models;

namespace Simple.GraphQL.Backend.GraphQL.GraphQLTypes
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the account type object.";
        }
    }
}