using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class MtoMTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroupFitnessClass_FitnessClasses_BookedClassesId",
                table: "CustomerGroupFitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroupFitnessClass_FitnessCustomers_BookedParticipantsId",
                table: "CustomerGroupFitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupFitnessClassTrainer_FitnessClasses_ClassesByTrainerId",
                table: "GroupFitnessClassTrainer");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupFitnessClassTrainer_FitnessTrainers_InstructorsId",
                table: "GroupFitnessClassTrainer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupFitnessClassTrainer",
                table: "GroupFitnessClassTrainer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerGroupFitnessClass",
                table: "CustomerGroupFitnessClass");

            migrationBuilder.RenameTable(
                name: "GroupFitnessClassTrainer",
                newName: "TrainerClassBookings");

            migrationBuilder.RenameTable(
                name: "CustomerGroupFitnessClass",
                newName: "CustomerClassBookings");

            migrationBuilder.RenameIndex(
                name: "IX_GroupFitnessClassTrainer_InstructorsId",
                table: "TrainerClassBookings",
                newName: "IX_TrainerClassBookings_InstructorsId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerGroupFitnessClass_BookedParticipantsId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "GroupFitnessClassTrainer");

            migrationBuilder.RenameTable(
                name: "CustomerClassBookings",
                newName: "CustomerGroupFitnessClass");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerClassBookings_InstructorsId",
                table: "GroupFitnessClassTrainer",
                newName: "IX_GroupFitnessClassTrainer_InstructorsId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerClassBookings_BookedParticipantsId",
                table: "CustomerGroupFitnessClass",
                newName: "IX_CustomerGroupFitnessClass_BookedParticipantsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupFitnessClassTrainer",
                table: "GroupFitnessClassTrainer",
                columns: new[] { "ClassesByTrainerId", "InstructorsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerGroupFitnessClass",
                table: "CustomerGroupFitnessClass",
                columns: new[] { "BookedClassesId", "BookedParticipantsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroupFitnessClass_FitnessClasses_BookedClassesId",
                table: "CustomerGroupFitnessClass",
                column: "BookedClassesId",
                principalTable: "FitnessClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroupFitnessClass_FitnessCustomers_BookedParticipantsId",
                table: "CustomerGroupFitnessClass",
                column: "BookedParticipantsId",
                principalTable: "FitnessCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupFitnessClassTrainer_FitnessClasses_ClassesByTrainerId",
                table: "GroupFitnessClassTrainer",
                column: "ClassesByTrainerId",
                principalTable: "FitnessClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupFitnessClassTrainer_FitnessTrainers_InstructorsId",
                table: "GroupFitnessClassTrainer",
                column: "InstructorsId",
                principalTable: "FitnessTrainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
