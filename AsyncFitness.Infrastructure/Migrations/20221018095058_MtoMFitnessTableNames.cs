using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class MtoMFitnessTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerClassBookings_FitnessClasses_BookedClassesId",
                table: "CustomerClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerClassBookings_FitnessCustomers_BookedParticipantsId",
                table: "CustomerClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerClassBookings_FitnessClasses_ClassesByTrainerId",
                table: "TrainerClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerClassBookings_FitnessTrainers_InstructorsId",
                table: "TrainerClassBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainerClassBookings",
                table: "TrainerClassBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerClassBookings",
                table: "CustomerClassBookings");

            migrationBuilder.RenameTable(
                name: "TrainerClassBookings",
                newName: "FitnessTrainerClassBookings");

            migrationBuilder.RenameTable(
                name: "CustomerClassBookings",
                newName: "FitnessCustomerClassBookings");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerClassBookings_InstructorsId",
                table: "FitnessTrainerClassBookings",
                newName: "IX_FitnessTrainerClassBookings_InstructorsId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerClassBookings_BookedParticipantsId",
                table: "FitnessCustomerClassBookings",
                newName: "IX_FitnessCustomerClassBookings_BookedParticipantsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessTrainerClassBookings",
                table: "FitnessTrainerClassBookings",
                columns: new[] { "ClassesByTrainerId", "InstructorsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCustomerClassBookings",
                table: "FitnessCustomerClassBookings",
                columns: new[] { "BookedClassesId", "BookedParticipantsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCustomerClassBookings_FitnessClasses_BookedClassesId",
                table: "FitnessCustomerClassBookings",
                column: "BookedClassesId",
                principalTable: "FitnessClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCustomerClassBookings_FitnessCustomers_BookedParticipantsId",
                table: "FitnessCustomerClassBookings",
                column: "BookedParticipantsId",
                principalTable: "FitnessCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessTrainerClassBookings_FitnessClasses_ClassesByTrainerId",
                table: "FitnessTrainerClassBookings",
                column: "ClassesByTrainerId",
                principalTable: "FitnessClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessTrainerClassBookings_FitnessTrainers_InstructorsId",
                table: "FitnessTrainerClassBookings",
                column: "InstructorsId",
                principalTable: "FitnessTrainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCustomerClassBookings_FitnessClasses_BookedClassesId",
                table: "FitnessCustomerClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCustomerClassBookings_FitnessCustomers_BookedParticipantsId",
                table: "FitnessCustomerClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessTrainerClassBookings_FitnessClasses_ClassesByTrainerId",
                table: "FitnessTrainerClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessTrainerClassBookings_FitnessTrainers_InstructorsId",
                table: "FitnessTrainerClassBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessTrainerClassBookings",
                table: "FitnessTrainerClassBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCustomerClassBookings",
                table: "FitnessCustomerClassBookings");

            migrationBuilder.RenameTable(
                name: "FitnessTrainerClassBookings",
                newName: "TrainerClassBookings");

            migrationBuilder.RenameTable(
                name: "FitnessCustomerClassBookings",
                newName: "CustomerClassBookings");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessTrainerClassBookings_InstructorsId",
                table: "TrainerClassBookings",
                newName: "IX_TrainerClassBookings_InstructorsId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomerClassBookings_BookedParticipantsId",
                table: "CustomerClassBookings",
                newName: "IX_CustomerClassBookings_BookedParticipantsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainerClassBookings",
                table: "TrainerClassBookings",
                columns: new[] { "ClassesByTrainerId", "InstructorsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerClassBookings",
                table: "CustomerClassBookings",
                columns: new[] { "BookedClassesId", "BookedParticipantsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerClassBookings_FitnessClasses_BookedClassesId",
                table: "CustomerClassBookings",
                column: "BookedClassesId",
                principalTable: "FitnessClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerClassBookings_FitnessCustomers_BookedParticipantsId",
                table: "CustomerClassBookings",
                column: "BookedParticipantsId",
                principalTable: "FitnessCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerClassBookings_FitnessClasses_ClassesByTrainerId",
                table: "TrainerClassBookings",
                column: "ClassesByTrainerId",
                principalTable: "FitnessClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerClassBookings_FitnessTrainers_InstructorsId",
                table: "TrainerClassBookings",
                column: "InstructorsId",
                principalTable: "FitnessTrainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
