using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class CenterConcepts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessConcepts_FitnessCenters_FitnessCenterId",
                table: "FitnessConcepts");

            migrationBuilder.DropIndex(
                name: "IX_FitnessConcepts_FitnessCenterId",
                table: "FitnessConcepts");

            migrationBuilder.DropColumn(
                name: "FitnessCenterId",
                table: "FitnessConcepts");

            migrationBuilder.CreateTable(
                name: "FitnessCenterConcepts",
                columns: table => new
                {
                    AvailableConceptsId = table.Column<int>(type: "int", nullable: false),
                    CentersWithConceptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessCenterConcepts", x => new { x.AvailableConceptsId, x.CentersWithConceptId });
                    table.ForeignKey(
                        name: "FK_FitnessCenterConcepts_FitnessCenters_CentersWithConceptId",
                        column: x => x.CentersWithConceptId,
                        principalTable: "FitnessCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessCenterConcepts_FitnessConcepts_AvailableConceptsId",
                        column: x => x.AvailableConceptsId,
                        principalTable: "FitnessConcepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessCenterConcepts_CentersWithConceptId",
                table: "FitnessCenterConcepts",
                column: "CentersWithConceptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessCenterConcepts");

            migrationBuilder.AddColumn<int>(
                name: "FitnessCenterId",
                table: "FitnessConcepts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FitnessConcepts_FitnessCenterId",
                table: "FitnessConcepts",
                column: "FitnessCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessConcepts_FitnessCenters_FitnessCenterId",
                table: "FitnessConcepts",
                column: "FitnessCenterId",
                principalTable: "FitnessCenters",
                principalColumn: "Id");
        }
    }
}
