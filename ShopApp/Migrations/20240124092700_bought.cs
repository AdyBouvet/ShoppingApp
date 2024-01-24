using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class bought : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Bought",
                table: "ItemShoppingList",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bought",
                table: "ItemShoppingList");
        }
    }
}
