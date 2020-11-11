using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeserializationSample.Migrations
{
    public partial class AddFileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Catalogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LoadedAt",
                table: "Catalogs",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "LoadedAt",
                table: "Catalogs");
        }
    }
}
