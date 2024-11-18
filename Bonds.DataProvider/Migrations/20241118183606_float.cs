using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bonds.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class @float : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "YieldAtPrevWaPrice",
                table: "Bonds",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "PrevWaPrice",
                table: "Bonds",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "PrevPrice",
                table: "Bonds",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "PrevLegalClosePrice",
                table: "Bonds",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFloater",
                table: "Bonds",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "FaceValue",
                table: "Bonds",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CouponValue",
                table: "Bonds",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "CouponPercent",
                table: "Bonds",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "YieldAtPrevWaPrice",
                table: "Bonds",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PrevWaPrice",
                table: "Bonds",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PrevPrice",
                table: "Bonds",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PrevLegalClosePrice",
                table: "Bonds",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFloater",
                table: "Bonds",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<double>(
                name: "FaceValue",
                table: "Bonds",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CouponValue",
                table: "Bonds",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CouponPercent",
                table: "Bonds",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
