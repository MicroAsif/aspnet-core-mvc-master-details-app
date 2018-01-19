using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace aspnetcoremaster.data.Migrations
{
    public partial class finalMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "InventoryItem");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "InventoryItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Inventory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Category",
                nullable: false,
                defaultValue: false);
        }
    }
}
