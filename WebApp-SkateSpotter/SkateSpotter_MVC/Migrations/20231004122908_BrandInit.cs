using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkateSpotter_MVC.Migrations
{
    /// <inheritdoc />
    public partial class BrandInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Store");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Store",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Store",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Store",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Store",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Store",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Store",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Store",
                table: "Store",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Store_OwnerId1",
                table: "Store",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_IdentityUser_OwnerId1",
                table: "Store",
                column: "OwnerId1",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_IdentityUser_OwnerId1",
                table: "Store");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Store",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Store_OwnerId1",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Store");

            migrationBuilder.RenameTable(
                name: "Store",
                newName: "Stores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");
        }
    }
}
