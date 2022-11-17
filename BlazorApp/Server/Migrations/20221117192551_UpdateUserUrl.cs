using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class UpdateUserUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Users");
        }
    }
}
