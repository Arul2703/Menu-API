using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMenuApi.Migrations
{
    /// <inheritdoc />
    public partial class isVegan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVegan",
                table: "FoodItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVegan",
                table: "FoodItems");
        }
    }
}
