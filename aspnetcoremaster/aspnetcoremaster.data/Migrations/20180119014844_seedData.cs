using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace aspnetcoremaster.data.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, UpdatedDate, CreatedDate) VALUES ('Category1', '1-19-2017', '1-19-2017')");
            migrationBuilder.Sql("INSERT INTO Category (CategoryName, UpdatedDate, CreatedDate ) VALUES ('Category2', '1-19-2017', '1-19-2017')");

            migrationBuilder.Sql("INSERT INTO Customer (Name,Mobile, UpdatedDate, CreatedDate) VALUES ('Customer 1', '0172350212', '1-19-2017', '1-19-2017')");
            migrationBuilder.Sql("INSERT INTO Customer (Name,Mobile, UpdatedDate, CreatedDate) VALUES ('Customer 2', '0171371520', '1-19-2017', '1-19-2017')");

            migrationBuilder.Sql("INSERT INTO Products (Name, Price,CategoryId, UpdatedDate, CreatedDate) VALUES ('Product 1', 12, (SELECT ID FROM Category WHERE CategoryName = 'Category1'), '1-19-2017', '1-19-2017')");
            migrationBuilder.Sql("INSERT INTO Products (Name, Price,CategoryId, UpdatedDate, CreatedDate) VALUES ('Product 2', 15, (SELECT ID FROM Category WHERE CategoryName = 'Category1'), '1-19-2017', '1-19-2017')");

            migrationBuilder.Sql("INSERT INTO Products (Name, Price,CategoryId, UpdatedDate, CreatedDate) VALUES ('Product 2 A', 16, (SELECT ID FROM Category WHERE CategoryName = 'Category2'), '1-19-2017', '1-19-2017')");
            migrationBuilder.Sql("INSERT INTO Products (Name, Price,CategoryId, UpdatedDate, CreatedDate) VALUES ('Product 2 B', 10, (SELECT ID FROM Category WHERE CategoryName = 'Category2'), '1-19-2017', '1-19-2017')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
