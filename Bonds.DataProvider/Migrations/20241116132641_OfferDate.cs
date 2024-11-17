using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bonds.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class OfferDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OfferDate",
                table: "Bonds",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferDate",
                table: "Bonds");
        }
    }
}
