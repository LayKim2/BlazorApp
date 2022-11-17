using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class UpdatePortfolio7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Concept1ImageData1",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Concept1ImageData2",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Concept1ImageData3",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Concept1VideoUrl1",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Concept1VideoUrl2",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Concept2ImageData1",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Concept2ImageData2",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Concept2ImageData3",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Concept2VideoUrl1",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Concept2VideoUrl2",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concept1ImageData1",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Concept1ImageData2",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Concept1ImageData3",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Concept1VideoUrl1",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Concept1VideoUrl2",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Concept2ImageData1",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Concept2ImageData2",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Concept2ImageData3",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Concept2VideoUrl1",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Concept2VideoUrl2",
                table: "Portfolios");
        }
    }
}
