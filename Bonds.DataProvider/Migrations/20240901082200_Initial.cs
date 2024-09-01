using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bonds.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bonds",
                columns: table => new
                {
                    ISIN = table.Column<string>(type: "text", nullable: false),
                    Bid = table.Column<double>(type: "double precision", nullable: true),
                    Ask = table.Column<double>(type: "double precision", nullable: true),
                    Spread = table.Column<double>(type: "double precision", nullable: true),
                    Open = table.Column<double>(type: "double precision", nullable: false),
                    Low = table.Column<double>(type: "double precision", nullable: false),
                    High = table.Column<double>(type: "double precision", nullable: false),
                    Last = table.Column<double>(type: "double precision", nullable: false),
                    Qty = table.Column<double>(type: "double precision", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    Yield = table.Column<double>(type: "double precision", nullable: false),
                    WaPrice = table.Column<double>(type: "double precision", nullable: false),
                    YieldAtWaPrice = table.Column<double>(type: "double precision", nullable: false),
                    CouponValue = table.Column<double>(type: "double precision", nullable: false),
                    MarketPriceToday = table.Column<double>(type: "double precision", nullable: false),
                    MarketPrice = table.Column<double>(type: "double precision", nullable: false),
                    TradesCount = table.Column<double>(type: "double precision", nullable: false),
                    VolToday = table.Column<long>(type: "bigint", nullable: false),
                    ValToday = table.Column<long>(type: "bigint", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Change = table.Column<double>(type: "double precision", nullable: false),
                    PriceMinusPrevWaPrice = table.Column<double>(type: "double precision", nullable: false),
                    YieldLastCoupon = table.Column<double>(type: "double precision", nullable: false),
                    SeqNum = table.Column<double>(type: "double precision", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonds", x => x.ISIN);
                });

            migrationBuilder.CreateTable(
                name: "BondsExtended",
                columns: table => new
                {
                    ISIN = table.Column<string>(type: "text", nullable: false),
                    EmitterId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondsExtended", x => x.ISIN);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonds");

            migrationBuilder.DropTable(
                name: "BondsExtended");
        }
    }
}
