﻿using System;
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
                name: "Bonds",
                columns: table => new
                {
                    ISIN = table.Column<string>(type: "text", nullable: false),
                    BoardId = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    PrevWaPrice = table.Column<double>(type: "double precision", nullable: true),
                    YieldAtPrevWaPrice = table.Column<double>(type: "double precision", nullable: true),
                    CouponValue = table.Column<double>(type: "double precision", nullable: true),
                    NextCouponDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PrevPrice = table.Column<double>(type: "double precision", nullable: true),
                    LotSize = table.Column<long>(type: "bigint", nullable: true),
                    FaceValue = table.Column<double>(type: "double precision", nullable: true),
                    BoardName = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    MatDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CouponPeriod = table.Column<int>(type: "integer", nullable: true),
                    IssueSize = table.Column<long>(type: "bigint", nullable: true),
                    PrevLegalClosePrice = table.Column<double>(type: "double precision", nullable: true),
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
                    CouponPercent = table.Column<double>(type: "double precision", nullable: true),
                    SettleDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsFloater = table.Column<bool>(type: "boolean", nullable: true)
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
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