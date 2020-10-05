using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    public partial class sdfsg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbreHeureTravail",
                table: "ChConsommationsEau");

            migrationBuilder.DropColumn(
                name: "PrixUnitaireEau",
                table: "ChConsommationsEau");

            migrationBuilder.DropColumn(
                name: "PrixUnitaireSel",
                table: "ChConsommationsEau");

            migrationBuilder.DropColumn(
                name: "VolumeEau",
                table: "ChConsommationsEau");

            migrationBuilder.AddColumn<bool>(
                name: "PrixUnitaireOsmose",
                table: "ChConsommationsEau",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixUnitaireOsmose",
                table: "ChConsommationsEau");

            migrationBuilder.AddColumn<int>(
                name: "NbreHeureTravail",
                table: "ChConsommationsEau",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixUnitaireEau",
                table: "ChConsommationsEau",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrixUnitaireSel",
                table: "ChConsommationsEau",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VolumeEau",
                table: "ChConsommationsEau",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
