using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class CreateAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Joined = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Email", "Joined", "Username" },
                values: new object[] { 1, "playerone@gmail.co.uk", new DateTime(2020, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "player" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Email", "Joined", "Username" },
                values: new object[] { 2, "threepigs@gmail.co.uk", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "threepigs" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Email", "Joined", "Username" },
                values: new object[] { 3, "johnsmith@hotmail.co.uk", new DateTime(2020, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "marioscat" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_Email",
                table: "Players",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Username",
                table: "Players",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
