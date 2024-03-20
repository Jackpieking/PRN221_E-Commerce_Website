using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN221_E_Commerce_Website.Migrations
{
    /// <inheritdoc />
    public partial class version_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Order Detail",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Order Detail");
        }
    }
}
