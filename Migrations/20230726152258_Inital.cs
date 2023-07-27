using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiMVCApplication.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_group",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_state",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_state", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    user_group_id = table.Column<int>(type: "integer", nullable: true),
                    user_state_id = table.Column<int>(type: "integer", nullable: true, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_user_group_user_group_id",
                        column: x => x.user_group_id,
                        principalTable: "user_group",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_user_state_user_state_id",
                        column: x => x.user_state_id,
                        principalTable: "user_state",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "user_group",
                columns: new[] { "id", "code", "description" },
                values: new object[,]
                {
                    { 1, "Admin", "Administrator actions" },
                    { 2, "User", "Users actions" }
                });

            migrationBuilder.InsertData(
                table: "user_state",
                columns: new[] { "id", "code", "description" },
                values: new object[,]
                {
                    { 1, "Active", "Active user" },
                    { 2, "Blocked", "Blocked user" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "created_date", "login", "password", "user_group_id" },
                values: new object[] { 1, new DateTime(2023, 7, 26, 15, 22, 57, 918, DateTimeKind.Utc).AddTicks(5825), "Venik", "Hello", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_user_user_group_id",
                table: "user",
                column: "user_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_user_state_id",
                table: "user",
                column: "user_state_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "user_group");

            migrationBuilder.DropTable(
                name: "user_state");
        }
    }
}
