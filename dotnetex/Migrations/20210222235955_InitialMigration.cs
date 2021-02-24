using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetex.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    user_email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    user_password = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    user_birthday = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
