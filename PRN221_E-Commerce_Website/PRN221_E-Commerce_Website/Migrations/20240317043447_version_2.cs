using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN221_E_Commerce_Website.Migrations
{
    /// <inheritdoc />
    public partial class version_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Order Detail",
                table: "Order Detail");

            migrationBuilder.DropColumn(
                name: "Adult",
                table: "Order Detail");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Order Detail");

            migrationBuilder.DropColumn(
                name: "Child",
                table: "Order Detail");

            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "Order Detail",
                newName: "OrderDate");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Order Detail",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Order Detail",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Order Detail",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Order",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Order",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order Detail",
                table: "Order Detail",
                columns: new[] { "OrderID", "PizzaId" });

            migrationBuilder.CreateIndex(
                name: "IX_Order Detail_OrderID",
                table: "Order Detail",
                column: "OrderID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Order Detail",
                table: "Order Detail");

            migrationBuilder.DropIndex(
                name: "IX_Order Detail_OrderID",
                table: "Order Detail");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Order Detail");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Order Detail");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Order Detail");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Order Detail",
                newName: "CheckOut");

            migrationBuilder.AddColumn<int>(
                name: "Adult",
                table: "Order Detail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "Order Detail",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Child",
                table: "Order Detail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order Detail",
                table: "Order Detail",
                column: "OrderID");
        }
    }
}
