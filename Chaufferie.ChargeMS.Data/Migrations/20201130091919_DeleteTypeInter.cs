using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chaufferie.ChargeMS.Data.Migrations
{
    public partial class DeleteTypeInter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChAssistExeternes_TypeInterventions_FkTypeIntervention",
                table: "ChAssistExeternes");

            migrationBuilder.DropTable(
                name: "TypeInterventions");

            migrationBuilder.DropIndex(
                name: "IX_ChAssistExeternes_FkTypeIntervention",
                table: "ChAssistExeternes");

            migrationBuilder.DropColumn(
                name: "FkTypeIntervention",
                table: "ChAssistExeternes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FkTypeIntervention",
                table: "ChAssistExeternes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TypeInterventions",
                columns: table => new
                {
                    TypeInterventionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeInterventions", x => x.TypeInterventionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChAssistExeternes_FkTypeIntervention",
                table: "ChAssistExeternes",
                column: "FkTypeIntervention");

            migrationBuilder.AddForeignKey(
                name: "FK_ChAssistExeternes_TypeInterventions_FkTypeIntervention",
                table: "ChAssistExeternes",
                column: "FkTypeIntervention",
                principalTable: "TypeInterventions",
                principalColumn: "TypeInterventionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
