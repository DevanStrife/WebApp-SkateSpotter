using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkateSpotter_MVC.Migrations
{
    /// <inheritdoc />
    public partial class StoreUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_IdentityUser_OwnerId1",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_Stores_OwnerId1",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "x_cord",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "y_cord",
                table: "Stores");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Stores");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Stores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "x_cord",
                table: "Stores",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "y_cord",
                table: "Stores",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_OwnerId1",
                table: "Stores",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_IdentityUser_OwnerId1",
                table: "Stores",
                column: "OwnerId1",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }
    }
}
