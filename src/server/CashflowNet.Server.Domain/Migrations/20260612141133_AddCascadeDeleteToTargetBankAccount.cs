using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashflowNet.Server.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDeleteToTargetBankAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_TargetBankAccountId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_TargetBankAccountId",
                table: "Transactions",
                column: "TargetBankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_TargetBankAccountId",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_TargetBankAccountId",
                table: "Transactions",
                column: "TargetBankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id");
        }
    }
}
