using ASPCoreGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace Simple.GraphQL.Backend.Models.Context
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var firstId = Guid.NewGuid();
            var secondId = Guid.NewGuid();

            modelBuilder.Entity<Owner>().HasData(
                        new Owner
                        {
                            Id = firstId,
                            Name = "John Doe",
                            Address = "Washington DC",
                        },
                        new Owner
                        {
                            Id = secondId,
                            Name = "Alex Green",
                            Address = "Texas",
                        }
                    );

            modelBuilder.Entity<Account>().HasData(new List<Account>() {
                        new Account { Id = Guid.NewGuid(), Type = TypeOfAccount.Savings, Description = "An account For savings", OwnerId = firstId } ,
                        new Account { Id = Guid.NewGuid(), Type = TypeOfAccount.Income, Description = "An account for incoms", OwnerId = firstId } ,
                        new Account { Id = Guid.NewGuid(), Type = TypeOfAccount.Cash, Description = "", OwnerId =secondId } ,
                        new Account { Id = Guid.NewGuid(), Type = TypeOfAccount.Income, Description = "", OwnerId =secondId } ,
                        new Account { Id = Guid.NewGuid(), Type = TypeOfAccount.Expense, Description = "" , OwnerId =secondId} ,
                        new Account { Id = Guid.NewGuid(), Type = TypeOfAccount.Expense, Description = "" , OwnerId =secondId} ,});
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}