using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioDigital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTokenFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpiresAt",
                table: "Tables",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenExpiresAt",
                table: "Tables");
        }
    }
}
