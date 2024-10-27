using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetAPI.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    AddedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entrys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<double>(type: "REAL", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    AddedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    AddedBy = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AddedBy", "DateAdded", "DateUpdated", "IsDeleted", "Name", "UpdatedBy" },
                values: new object[] { 1, -1, new DateTime(2024, 10, 27, 18, 32, 41, 889, DateTimeKind.Local).AddTicks(8881), new DateTime(2024, 10, 27, 18, 32, 41, 889, DateTimeKind.Local).AddTicks(8882), false, "test", -1 });

            migrationBuilder.InsertData(
                table: "Entrys",
                columns: new[] { "Id", "AddedBy", "Amount", "CategoryId", "Date", "DateAdded", "DateUpdated", "Description", "IsDeleted", "UpdatedBy" },
                values: new object[] { 1, -1, 1.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 27, 18, 32, 41, 889, DateTimeKind.Local).AddTicks(8892), new DateTime(2024, 10, 27, 18, 32, 41, 889, DateTimeKind.Local).AddTicks(8893), "test", false, -1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddedBy", "DateAdded", "DateUpdated", "Email", "IsDeleted", "Password", "UpdatedBy", "Username" },
                values: new object[] { 1, -1, new DateTime(2024, 10, 27, 18, 32, 41, 889, DateTimeKind.Local).AddTicks(8773), new DateTime(2024, 10, 27, 18, 32, 41, 889, DateTimeKind.Local).AddTicks(8814), null, false, "test", -1, "test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Entrys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
