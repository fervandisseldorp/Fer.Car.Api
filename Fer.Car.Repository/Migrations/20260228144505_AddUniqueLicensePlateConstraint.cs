using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fer.Car.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueLicensePlateConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cars_LicensePlateNumber",
                table: "Cars",
                column: "LicensePlateNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_LicensePlateNumber",
                table: "Cars");
        }
    }
}
