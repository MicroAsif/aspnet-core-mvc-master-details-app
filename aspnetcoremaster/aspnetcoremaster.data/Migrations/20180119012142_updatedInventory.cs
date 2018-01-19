using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace aspnetcoremaster.data.Migrations
{
    public partial class updatedInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "InventoryItem");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "InventoryItem",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "InventoryItem");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "InventoryItem",
                nullable: true);
        }
    }
}
