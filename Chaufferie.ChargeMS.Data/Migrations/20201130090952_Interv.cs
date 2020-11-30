using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    public partial class Interv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Intervention",
                table: "ChAssistExeternes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Intervention",
                table: "ChAssistExeternes");
        }
    }
}
