using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bonds.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BondsExtended",
                columns: table => new
                {
                    ISIN = table.Column<string>(type: "text", nullable: false),
                    EmitterId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondsExtended", x => x.ISIN);
                });

            migrationBuilder.CreateTable(
                name: "BondsMarketdata",
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
                    CurrentPrice = table.Column<double>(type: "double precision", nullable: false),
                    TradesCount = table.Column<long>(type: "bigint", nullable: false),
                    VolToday = table.Column<long>(type: "bigint", nullable: false),
                    ValToday = table.Column<long>(type: "bigint", nullable: false),
                    UpdateTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Change = table.Column<double>(type: "double precision", nullable: false),
                    PriceMinusPrevWaPrice = table.Column<double>(type: "double precision", nullable: false),
                    YieldLastCoupon = table.Column<double>(type: "double precision", nullable: false),
                    SeqNum = table.Column<double>(type: "double precision", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondsMarketdata", x => x.ISIN);
                });

            migrationBuilder.CreateTable(
                name: "BondsSecurities",
                columns: table => new
                {
                    ISIN = table.Column<string>(type: "text", nullable: false),
                    BoardId = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    PrevWaPrice = table.Column<float>(type: "real", nullable: true),
                    YieldAtPrevWaPrice = table.Column<float>(type: "real", nullable: true),
                    CouponValue = table.Column<float>(type: "real", nullable: true),
                    NextCouponDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PrevPrice = table.Column<float>(type: "real", nullable: true),
                    LotSize = table.Column<long>(type: "bigint", nullable: true),
                    FaceValue = table.Column<float>(type: "real", nullable: true),
                    BoardName = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    MatDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CouponPeriod = table.Column<int>(type: "integer", nullable: false),
                    IssueSize = table.Column<long>(type: "bigint", nullable: true),
                    PrevLegalClosePrice = table.Column<float>(type: "real", nullable: true),
                    PrevDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SecName = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    FACEUNIT = table.Column<string>(type: "text", nullable: true),
                    BuybackPrice = table.Column<string>(type: "text", nullable: true),
                    BuybackDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LatName = table.Column<string>(type: "text", nullable: true),
                    RegNumber = table.Column<string>(type: "text", nullable: true),
                    CurrencyId = table.Column<string>(type: "text", nullable: true),
                    SecType = table.Column<string>(type: "text", nullable: true),
                    CouponPercent = table.Column<float>(type: "real", nullable: true),
                    SettleDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OfferDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsFloater = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondsSecurities", x => x.ISIN);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BondsExtended");

            migrationBuilder.DropTable(
                name: "BondsMarketdata");

            migrationBuilder.DropTable(
                name: "BondsSecurities");
        }
    }
}
