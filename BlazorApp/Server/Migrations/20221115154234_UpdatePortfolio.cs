using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class UpdatePortfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutBirthday",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutIntroduce",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutSize",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CameraTestDateUpdated",
                table: "Portfolios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HighlightDateUpdated",
                table: "Portfolios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RightEnglishName",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RightName",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutBirthday",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "AboutIntroduce",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "AboutSize",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "CameraTestDateUpdated",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "HighlightDateUpdated",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "RightEnglishName",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "RightName",
                table: "Portfolios");
        }
    }
}
