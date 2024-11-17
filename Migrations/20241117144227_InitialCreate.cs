using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace order_system.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealSelections_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealSelections_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8470), "admin@example.com", "123456", 1, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8470), "admin" },
                    { 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8520), "user0@example.com", "123456", 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8530), "user0" },
                    { 3, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8540), "user1@example.com", "123456", 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8540), "user1" },
                    { 4, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8560), "user2@example.com", "123456", 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8560), "user2" },
                    { 5, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8570), "user3@example.com", "123456", 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8570), "user3" },
                    { 6, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8600), "user4@example.com", "123456", 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8600), "user4" },
                    { 7, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8610), "user5@example.com", "123456", 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8610), "user5" },
                    { 8, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8620), "user6@example.com", "123456", 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8620), "user6" },
                    { 9, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8640), "user7@example.com", "123456", 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8640), "user7" },
                    { 10, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8660), "user8@example.com", "123456", 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8660), "user8" },
                    { 11, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8670), "user9@example.com", "123456", 2, new DateTime(2024, 11, 17, 22, 42, 27, 534, DateTimeKind.Local).AddTicks(8670), "user9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealSelections_MenuId",
                table: "MealSelections",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MealSelections_UserId",
                table: "MealSelections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealSelections");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
