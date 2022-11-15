using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class UpdatePortfolio3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutMainFilmograpy1",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutMainFilmograpy2",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutMainFilmograpy3",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutMainFilmograpy4",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMainFilmograpy1",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "AboutMainFilmograpy2",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "AboutMainFilmograpy3",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "AboutMainFilmograpy4",
                table: "Portfolios");
        }
    }
}
