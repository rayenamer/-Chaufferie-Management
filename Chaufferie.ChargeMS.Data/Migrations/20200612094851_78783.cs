using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    public partial class _78783 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chCombustibles",
                columns: table => new
                {
                    ChCombustibleId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PCS = table.Column<decimal>(nullable: false),
                    CoefficientDeCorrection = table.Column<decimal>(nullable: false),
                    QuantiteConsomme = table.Column<decimal>(nullable: false),
                    PrixUnitaire = table.Column<decimal>(nullable: false),
                    FkSubsidiary = table.Column<Guid>(nullable: false),
                    FilialesubsidiaryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chCombustibles", x => x.ChCombustibleId);
                    table.ForeignKey(
                        name: "FK_chCombustibles_Filiales_FilialesubsidiaryId",
                        column: x => x.FilialesubsidiaryId,
                        principalTable: "Filiales",
                        principalColumn: "subsidiaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chElectriques",
                columns: table => new
                {
                    ChElectriqueId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    QuantiteConsomme = table.Column<decimal>(nullable: false),
                    PrixUnitaire = table.Column<decimal>(nullable: false),
                    FkSubsidiary = table.Column<Guid>(nullable: false),
                    FilialesubsidiaryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chElectriques", x => x.ChElectriqueId);
                    table.ForeignKey(
                        name: "FK_chElectriques_Filiales_FilialesubsidiaryId",
                        column: x => x.FilialesubsidiaryId,
                        principalTable: "Filiales",
                        principalColumn: "subsidiaryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chCombustibles_FilialesubsidiaryId",
                table: "chCombustibles",
                column: "FilialesubsidiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_chElectriques_FilialesubsidiaryId",
                table: "chElectriques",
                column: "FilialesubsidiaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chCombustibles");

            migrationBuilder.DropTable(
                name: "chElectriques");
        }
    }
}
