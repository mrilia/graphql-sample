using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Simple.GraphQL.Backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("9a82dafa-1648-4ac6-904c-47a5dffc9db4"), "Texas", "Alex Green" },
                    { new Guid("a402fe7c-b959-49f4-b10a-58540da2bde5"), "Washington DC", "John Doe" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[,]
                {
                    { new Guid("69a7a04a-3b21-4001-a77f-593794224f99"), "", new Guid("9a82dafa-1648-4ac6-904c-47a5dffc9db4"), 0 },
                    { new Guid("6ffc52bd-8a1c-4471-a169-544f9b16ed61"), "", new Guid("9a82dafa-1648-4ac6-904c-47a5dffc9db4"), 2 },
                    { new Guid("94a451c6-cc53-481a-b59e-a91a451dc5c2"), "", new Guid("9a82dafa-1648-4ac6-904c-47a5dffc9db4"), 2 },
                    { new Guid("e546cee7-0e68-44ec-b01c-95cf5ffd08b6"), "", new Guid("9a82dafa-1648-4ac6-904c-47a5dffc9db4"), 3 },
                    { new Guid("e8306da0-dfb4-48fe-b40e-b080fbeada55"), "An account for incoms", new Guid("a402fe7c-b959-49f4-b10a-58540da2bde5"), 3 },
                    { new Guid("f5605377-580d-485c-8376-f1f2f5757127"), "An account For savings", new Guid("a402fe7c-b959-49f4-b10a-58540da2bde5"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OwnerId",
                table: "Accounts",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
