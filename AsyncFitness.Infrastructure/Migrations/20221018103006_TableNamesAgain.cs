using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class TableNamesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessConceptsAtCenter_FitnessCenter_CentersWithConceptId",
                table: "FitnessConceptsAtCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessConceptsAtCenter_FitnessConcept_AvailableConceptsId",
                table: "FitnessConceptsAtCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessConceptsAtCenter",
                table: "FitnessConceptsAtCenter");

            migrationBuilder.RenameTable(
                name: "FitnessConceptsAtCenter",
                newName: "FitnessConceptAtCenter");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessConceptsAtCenter_CentersWithConceptId",
                table: "FitnessConceptAtCenter",
                newName: "IX_FitnessConceptAtCenter_CentersWithConceptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessConceptAtCenter",
                table: "FitnessConceptAtCenter",
                columns: new[] { "AvailableConceptsId", "CentersWithConceptId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessConceptAtCenter_FitnessCenter_CentersWithConceptId",
                table: "FitnessConceptAtCenter",
                column: "CentersWithConceptId",
                principalTable: "FitnessCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessConceptAtCenter_FitnessConcept_AvailableConceptsId",
                table: "FitnessConceptAtCenter",
                column: "AvailableConceptsId",
                principalTable: "FitnessConcept",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessConceptAtCenter_FitnessCenter_CentersWithConceptId",
                table: "FitnessConceptAtCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessConceptAtCenter_FitnessConcept_AvailableConceptsId",
                table: "FitnessConceptAtCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessConceptAtCenter",
                table: "FitnessConceptAtCenter");

            migrationBuilder.RenameTable(
                name: "FitnessConceptAtCenter",
                newName: "FitnessConceptsAtCenter");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessConceptAtCenter_CentersWithConceptId",
                table: "FitnessConceptsAtCenter",
                newName: "IX_FitnessConceptsAtCenter_CentersWithConceptId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessConceptsAtCenter",
                table: "FitnessConceptsAtCenter",
                columns: new[] { "AvailableConceptsId", "CentersWithConceptId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessConceptsAtCenter_FitnessCenter_CentersWithConceptId",
                table: "FitnessConceptsAtCenter",
                column: "CentersWithConceptId",
                principalTable: "FitnessCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessConceptsAtCenter_FitnessConcept_AvailableConceptsId",
                table: "FitnessConceptsAtCenter",
                column: "AvailableConceptsId",
                principalTable: "FitnessConcept",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
