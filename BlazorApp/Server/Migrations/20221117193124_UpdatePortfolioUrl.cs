using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class UpdatePortfolioUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Portfolios");
        }
    }
}
