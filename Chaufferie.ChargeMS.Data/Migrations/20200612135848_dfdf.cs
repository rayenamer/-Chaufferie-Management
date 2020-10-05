using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    public partial class dfdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chCombustibles_Filiales_FilialesubsidiaryId",
                table: "chCombustibles");

            migrationBuilder.DropForeignKey(
                name: "FK_chElectriques_Filiales_FilialesubsidiaryId",
                table: "chElectriques");

            migrationBuilder.DropIndex(
                name: "IX_chElectriques_FilialesubsidiaryId",
                table: "chElectriques");

            migrationBuilder.DropIndex(
                name: "IX_chCombustibles_FilialesubsidiaryId",
                table: "chCombustibles");

            migrationBuilder.DropColumn(
                name: "FilialesubsidiaryId",
                table: "chElectriques");

            migrationBuilder.DropColumn(
                name: "FilialesubsidiaryId",
                table: "chCombustibles");

            migrationBuilder.CreateIndex(
                name: "IX_chElectriques_FkSubsidiary",
                table: "chElectriques",
                column: "FkSubsidiary");

            migrationBuilder.CreateIndex(
                name: "IX_chCombustibles_FkSubsidiary",
                table: "chCombustibles",
                column: "FkSubsidiary");

            migrationBuilder.AddForeignKey(
                name: "FK_chCombustibles_Filiales_FkSubsidiary",
                table: "chCombustibles",
                column: "FkSubsidiary",
                principalTable: "Filiales",
                principalColumn: "subsidiaryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chElectriques_Filiales_FkSubsidiary",
                table: "chElectriques",
                column: "FkSubsidiary",
                principalTable: "Filiales",
                principalColumn: "subsidiaryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chCombustibles_Filiales_FkSubsidiary",
                table: "chCombustibles");

            migrationBuilder.DropForeignKey(
                name: "FK_chElectriques_Filiales_FkSubsidiary",
                table: "chElectriques");

            migrationBuilder.DropIndex(
                name: "IX_chElectriques_FkSubsidiary",
                table: "chElectriques");

            migrationBuilder.DropIndex(
                name: "IX_chCombustibles_FkSubsidiary",
                table: "chCombustibles");

            migrationBuilder.AddColumn<Guid>(
                name: "FilialesubsidiaryId",
                table: "chElectriques",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FilialesubsidiaryId",
                table: "chCombustibles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_chElectriques_FilialesubsidiaryId",
                table: "chElectriques",
                column: "FilialesubsidiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_chCombustibles_FilialesubsidiaryId",
                table: "chCombustibles",
                column: "FilialesubsidiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_chCombustibles_Filiales_FilialesubsidiaryId",
                table: "chCombustibles",
                column: "FilialesubsidiaryId",
                principalTable: "Filiales",
                principalColumn: "subsidiaryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chElectriques_Filiales_FilialesubsidiaryId",
                table: "chElectriques",
                column: "FilialesubsidiaryId",
                principalTable: "Filiales",
                principalColumn: "subsidiaryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
