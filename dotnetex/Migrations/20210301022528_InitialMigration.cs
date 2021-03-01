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
                    user_email = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    user_password = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    user_birthday = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2021, 2, 28, 23, 25, 28, 390, DateTimeKind.Local).AddTicks(4706))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_user_email",
                table: "users",
                column: "user_email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
