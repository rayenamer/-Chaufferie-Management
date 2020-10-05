using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    public partial class _54543 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consommables_Fournisseurs_FournisseurId",
                table: "Consommables");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropIndex(
                name: "IX_Consommables_FournisseurId",
                table: "Consommables");

            migrationBuilder.DropColumn(
                name: "FournisseurId",
                table: "Consommables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FournisseurId",
                table: "Consommables",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    FournisseurId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.FournisseurId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consommables_FournisseurId",
                table: "Consommables",
                column: "FournisseurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consommables_Fournisseurs_FournisseurId",
                table: "Consommables",
                column: "FournisseurId",
                principalTable: "Fournisseurs",
                principalColumn: "FournisseurId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
