using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    public partial class _44442 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "quantiteEauConsommee",
                table: "chElectriques",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "quantiteVapeurProduite",
                table: "chElectriques",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantiteEauConsommee",
                table: "chElectriques");

            migrationBuilder.DropColumn(
                name: "quantiteVapeurProduite",
                table: "chElectriques");
        }
    }
}
