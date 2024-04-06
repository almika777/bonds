using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bonds.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BondQuotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ISIN = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    PrevPrice = table.Column<double>(type: "double precision", nullable: true),
                    LotSize = table.Column<long>(type: "bigint", nullable: true),
                    FaceValue = table.Column<double>(type: "double precision", nullable: true),
                    BoardName = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    MatDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CouponPeriod = table.Column<int>(type: "integer", nullable: true),
                    IssueSize = table.Column<long>(type: "bigint", nullable: true),
                    PrevLegalClosePrice = table.Column<double>(type: "double precision", nullable: true),
                    PrevDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SecName = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    FaceUnit = table.Column<string>(type: "text", nullable: true),
                    BuybackPrice = table.Column<string>(type: "text", nullable: true),
                    BuybackDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LatName = table.Column<string>(type: "text", nullable: true),
                    RegNumber = table.Column<string>(type: "text", nullable: true),
                    CurrencyId = table.Column<string>(type: "text", nullable: true),
                    SecType = table.Column<string>(type: "text", nullable: true),
                    CouponPercent = table.Column<double>(type: "double precision", nullable: true),
                    SettleDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondQuotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BondTrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TradeId = table.Column<long>(type: "bigint", nullable: false),
                    TradeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SecId = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    Yield = table.Column<double>(type: "double precision", nullable: false),
                    BuySell = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondTrades", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BondQuotes");

            migrationBuilder.DropTable(
                name: "BondTrades");
        }
    }
}
