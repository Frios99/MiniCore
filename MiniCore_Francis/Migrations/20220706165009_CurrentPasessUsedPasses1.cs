using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniCore_Francis.Migrations
{
    public partial class CurrentPasessUsedPasses1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsedPassed",
                table: "minicores",
                newName: "UsedPasses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsedPasses",
                table: "minicores",
                newName: "UsedPassed");
        }
    }
}
