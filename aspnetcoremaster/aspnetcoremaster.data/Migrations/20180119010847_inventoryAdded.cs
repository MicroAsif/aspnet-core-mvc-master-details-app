using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace aspnetcoremaster.data.Migrations
{
    public partial class inventoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryModelId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryModelId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryModelId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryModelId",
                table: "Products",
                column: "CategoryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryModelId",
                table: "Products",
                column: "CategoryModelId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
