using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniCore_Francis.Migrations
{
    public partial class CurrentPasessUsedPasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passes",
                table: "minicores",
                newName: "UsedPassed");

            migrationBuilder.AddColumn<int>(
                name: "CurrentPasses",
                table: "minicores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPasses",
                table: "minicores");

            migrationBuilder.RenameColumn(
                name: "UsedPassed",
                table: "minicores",
                newName: "Passes");
        }
    }
}
