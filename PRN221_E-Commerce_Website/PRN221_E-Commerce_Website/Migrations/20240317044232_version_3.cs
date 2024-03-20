using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN221_E_Commerce_Website.Migrations
{
    /// <inheritdoc />
    public partial class version_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Order Detail",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Order Detail",
                newName: "TotalPrice");
        }
    }
}
