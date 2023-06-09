using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMenuApi.Migrations
{
    /// <inheritdoc />
    public partial class Calories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Calories",
                table: "FoodItems",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "FoodItems");
        }
    }
}
