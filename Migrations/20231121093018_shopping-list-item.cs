using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class shoppinglistitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemShoppingList",
                table: "ItemShoppingList");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ItemShoppingList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "ItemShoppingList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "ItemShoppingList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemShoppingList",
                table: "ItemShoppingList",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemShoppingList_ItemId",
                table: "ItemShoppingList",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemShoppingList",
                table: "ItemShoppingList");

            migrationBuilder.DropIndex(
                name: "IX_ItemShoppingList_ItemId",
                table: "ItemShoppingList");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemShoppingList");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ItemShoppingList");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "ItemShoppingList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemShoppingList",
                table: "ItemShoppingList",
                columns: new[] { "ItemId", "ShoppingListId" });
        }
    }
}
