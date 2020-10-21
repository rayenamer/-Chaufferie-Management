using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    public partial class attachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ChPieceRechanges",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "ChPieceRechanges",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ChAssistExeternes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "ChAssistExeternes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ChPieceRechanges");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "ChPieceRechanges");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ChAssistExeternes");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "ChAssistExeternes");
        }
    }
}
