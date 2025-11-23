using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioDigital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatePaymentTokenRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                newName: "PaymentToken");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PaymentToken",
                newName: "PaymentMethods");
        }

    }
}
