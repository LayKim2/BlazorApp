using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class UpdatePortfolio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Portfolios",
                newName: "AboutAge");

            migrationBuilder.AddColumn<string>(
                name: "AboutEmail",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutEmail",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "AboutAge",
                table: "Portfolios",
                newName: "Age");
        }
    }
}
