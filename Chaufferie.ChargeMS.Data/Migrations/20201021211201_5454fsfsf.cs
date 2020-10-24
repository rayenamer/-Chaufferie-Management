using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    public partial class _5454fsfsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrixUnitaire",
                table: "Consommables",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrixUnitaire",
                table: "Consommables",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");
        }
    }
}
