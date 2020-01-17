using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace kelolakeuangan.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id_Account = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Id_Family = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id_Account);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    Id_Income = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    AccountId_Account = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.Id_Income);
                    table.ForeignKey(
                        name: "FK_Income_Account_AccountId_Account",
                        column: x => x.AccountId_Account,
                        principalTable: "Account",
                        principalColumn: "Id_Account",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spending",
                columns: table => new
                {
                    Id_Spending = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    AccountId_Account = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spending", x => x.Id_Spending);
                    table.ForeignKey(
                        name: "FK_Spending_Account_AccountId_Account",
                        column: x => x.AccountId_Account,
                        principalTable: "Account",
                        principalColumn: "Id_Account",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id_Wallet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Limit = table.Column<double>(nullable: false),
                    AccountId_Account = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id_Wallet);
                    table.ForeignKey(
                        name: "FK_Wallet_Account_AccountId_Account",
                        column: x => x.AccountId_Account,
                        principalTable: "Account",
                        principalColumn: "Id_Account",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Income_AccountId_Account",
                table: "Income",
                column: "AccountId_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Spending_AccountId_Account",
                table: "Spending",
                column: "AccountId_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_AccountId_Account",
                table: "Wallet",
                column: "AccountId_Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "Spending");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
