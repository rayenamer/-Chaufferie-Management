using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    public partial class _1222222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BureauControles",
                columns: table => new
                {
                    BureauControleId = table.Column<Guid>(nullable: false),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BureauControles", x => x.BureauControleId);
                });

            migrationBuilder.CreateTable(
                name: "Filiales",
                columns: table => new
                {
                    subsidiaryId = table.Column<Guid>(nullable: false),
                    label = table.Column<string>(nullable: true),
                    subsidiaryCode = table.Column<string>(nullable: true),
                    logo = table.Column<byte>(nullable: true),
                    UniteCombustible = table.Column<int>(nullable: true),
                    UniteId = table.Column<Guid>(nullable: true),
                    SecteurId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiales", x => x.subsidiaryId);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    FournisseurId = table.Column<Guid>(nullable: false),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.FournisseurId);
                });

            migrationBuilder.CreateTable(
                name: "TypeConsommables",
                columns: table => new
                {
                    TypeConsommableId = table.Column<Guid>(nullable: false),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeConsommables", x => x.TypeConsommableId);
                });

            migrationBuilder.CreateTable(
                name: "TypeInterventions",
                columns: table => new
                {
                    TypeInterventionId = table.Column<Guid>(nullable: false),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeInterventions", x => x.TypeInterventionId);
                });

            migrationBuilder.CreateTable(
                name: "ChConsommationsEau",
                columns: table => new
                {
                    ChEauId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    QuantiteConsomme = table.Column<decimal>(nullable: false),
                    PrixUnitaire = table.Column<decimal>(nullable: false),
                    NbreHeureTravail = table.Column<int>(nullable: false),
                    VolumeEau = table.Column<decimal>(nullable: false),
                    PrixUnitaireSel = table.Column<decimal>(nullable: false),
                    PrixUnitaireEau = table.Column<decimal>(nullable: false),
                    FkSubsidiary = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChConsommationsEau", x => x.ChEauId);
                    table.ForeignKey(
                        name: "FK_ChConsommationsEau_Filiales_FkSubsidiary",
                        column: x => x.FkSubsidiary,
                        principalTable: "Filiales",
                        principalColumn: "subsidiaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChPersonnels",
                columns: table => new
                {
                    ChPersonnelId = table.Column<Guid>(nullable: false),
                    FkUser = table.Column<Guid>(nullable: false),
                    Salaire = table.Column<decimal>(nullable: false),
                    TauxOccupation = table.Column<decimal>(nullable: false),
                    FkSubsidiary = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChPersonnels", x => x.ChPersonnelId);
                    table.ForeignKey(
                        name: "FK_ChPersonnels_Filiales_FkSubsidiary",
                        column: x => x.FkSubsidiary,
                        principalTable: "Filiales",
                        principalColumn: "subsidiaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChPieceRechanges",
                columns: table => new
                {
                    ChPieceRechangeId = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Nombre = table.Column<int>(nullable: false),
                    NomFournisseur = table.Column<string>(nullable: true),
                    Montant = table.Column<decimal>(nullable: false),
                    FkSubsidiary = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChPieceRechanges", x => x.ChPieceRechangeId);
                    table.ForeignKey(
                        name: "FK_ChPieceRechanges_Filiales_FkSubsidiary",
                        column: x => x.FkSubsidiary,
                        principalTable: "Filiales",
                        principalColumn: "subsidiaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consommables",
                columns: table => new
                {
                    ConsommableId = table.Column<Guid>(nullable: false),
                    Nature = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    Consommation = table.Column<decimal>(nullable: false),
                    PrixUnitaire = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TypeConsommableId = table.Column<Guid>(nullable: false),
                    FournisseurId = table.Column<Guid>(nullable: false),
                    FkSubsidiary = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consommables", x => x.ConsommableId);
                    table.ForeignKey(
                        name: "FK_Consommables_Filiales_FkSubsidiary",
                        column: x => x.FkSubsidiary,
                        principalTable: "Filiales",
                        principalColumn: "subsidiaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consommables_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "FournisseurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consommables_TypeConsommables_TypeConsommableId",
                        column: x => x.TypeConsommableId,
                        principalTable: "TypeConsommables",
                        principalColumn: "TypeConsommableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChAssistExeternes",
                columns: table => new
                {
                    ChAssistExterneId = table.Column<Guid>(nullable: false),
                    Montant = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    SousTraitant = table.Column<string>(nullable: true),
                    FkTypeIntervention = table.Column<Guid>(nullable: false),
                    FkBureauControle = table.Column<Guid>(nullable: true),
                    FkSubsidiary = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChAssistExeternes", x => x.ChAssistExterneId);
                    table.ForeignKey(
                        name: "FK_ChAssistExeternes_BureauControles_FkBureauControle",
                        column: x => x.FkBureauControle,
                        principalTable: "BureauControles",
                        principalColumn: "BureauControleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChAssistExeternes_Filiales_FkSubsidiary",
                        column: x => x.FkSubsidiary,
                        principalTable: "Filiales",
                        principalColumn: "subsidiaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChAssistExeternes_TypeInterventions_FkTypeIntervention",
                        column: x => x.FkTypeIntervention,
                        principalTable: "TypeInterventions",
                        principalColumn: "TypeInterventionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChAssistExeternes_FkBureauControle",
                table: "ChAssistExeternes",
                column: "FkBureauControle");

            migrationBuilder.CreateIndex(
                name: "IX_ChAssistExeternes_FkSubsidiary",
                table: "ChAssistExeternes",
                column: "FkSubsidiary");

            migrationBuilder.CreateIndex(
                name: "IX_ChAssistExeternes_FkTypeIntervention",
                table: "ChAssistExeternes",
                column: "FkTypeIntervention");

            migrationBuilder.CreateIndex(
                name: "IX_ChConsommationsEau_FkSubsidiary",
                table: "ChConsommationsEau",
                column: "FkSubsidiary");

            migrationBuilder.CreateIndex(
                name: "IX_ChPersonnels_FkSubsidiary",
                table: "ChPersonnels",
                column: "FkSubsidiary");

            migrationBuilder.CreateIndex(
                name: "IX_ChPieceRechanges_FkSubsidiary",
                table: "ChPieceRechanges",
                column: "FkSubsidiary");

            migrationBuilder.CreateIndex(
                name: "IX_Consommables_FkSubsidiary",
                table: "Consommables",
                column: "FkSubsidiary");

            migrationBuilder.CreateIndex(
                name: "IX_Consommables_FournisseurId",
                table: "Consommables",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Consommables_TypeConsommableId",
                table: "Consommables",
                column: "TypeConsommableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChAssistExeternes");

            migrationBuilder.DropTable(
                name: "ChConsommationsEau");

            migrationBuilder.DropTable(
                name: "ChPersonnels");

            migrationBuilder.DropTable(
                name: "ChPieceRechanges");

            migrationBuilder.DropTable(
                name: "Consommables");

            migrationBuilder.DropTable(
                name: "BureauControles");

            migrationBuilder.DropTable(
                name: "TypeInterventions");

            migrationBuilder.DropTable(
                name: "Filiales");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "TypeConsommables");
        }
    }
}
