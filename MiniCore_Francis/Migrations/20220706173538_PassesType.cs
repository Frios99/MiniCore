using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniCore_Francis.Migrations
{
    public partial class PassesType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "minicores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "minicores");
        }
    }
}
