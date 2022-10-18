using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class ConceptsAndClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_FitnessCenters_FitnessCenterId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Trainers_TrainerId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroupFitnessClass_Customers_BookedParticipantsId",
                table: "CustomerGroupFitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroupFitnessClass_GroupFitnessClass_BookedClassesId",
                table: "CustomerGroupFitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Subscriptions_SubscriptionName",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Trainers_TrainerId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCenters_Admins_GymLeaderId",
                table: "FitnessCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupFitnessClass_Classes_ConceptId",
                table: "GroupFitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupFitnessClass_Locations_LocationId",
                table: "GroupFitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupFitnessClassTrainer_GroupFitnessClass_ClassesByTrainerId",
                table: "GroupFitnessClassTrainer");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupFitnessClassTrainer_Trainers_InstructorsId",
                table: "GroupFitnessClassTrainer");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_FitnessCenters_CenterId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupFitnessClass",
                table: "GroupFitnessClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "FitnessTrainers");

            migrationBuilder.RenameTable(
                name: "Subscriptions",
                newName: "FitnessSubscriptions");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "FitnessLocations");

            migrationBuilder.RenameTable(
                name: "GroupFitnessClass",
                newName: "FitnessClasses");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "FitnessCustomers");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "FitnessConcepts");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "FitnessAdmins");

            migrationBuilder.RenameIndex(
                name: "IX_Trainers_Email",
                table: "FitnessTrainers",
                newName: "IX_FitnessTrainers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CenterId",
                table: "FitnessLocations",
                newName: "IX_FitnessLocations_CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupFitnessClass_LocationId",
                table: "FitnessClasses",
                newName: "IX_FitnessClasses_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupFitnessClass_ConceptId",
                table: "FitnessClasses",
                newName: "IX_FitnessClasses_ConceptId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_TrainerId",
                table: "FitnessCustomers",
                newName: "IX_FitnessCustomers_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_SubscriptionName",
                table: "FitnessCustomers",
                newName: "IX_FitnessCustomers_SubscriptionName");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Email",
                table: "FitnessCustomers",
                newName: "IX_FitnessCustomers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_TrainerId",
                table: "FitnessConcepts",
                newName: "IX_FitnessConcepts_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_FitnessCenterId",
                table: "FitnessConcepts",
                newName: "IX_FitnessConcepts_FitnessCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_Email",
                table: "FitnessAdmins",
                newName: "IX_FitnessAdmins_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessTrainers",
                table: "FitnessTrainers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessSubscriptions",
                table: "FitnessSubscriptions",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessLocations",
                table: "FitnessLocations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessClasses",
                table: "FitnessClasses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCustomers",
                table: "FitnessCustomers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessConcepts",
                table: "FitnessConcepts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessAdmins",
                table: "FitnessAdmins",
                column: "Id");

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
                name: "FK_FitnessCenters_FitnessAdmins_GymLeaderId",
                table: "FitnessCenters",
                column: "GymLeaderId",
                principalTable: "FitnessAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessClasses_FitnessConcepts_ConceptId",
                table: "FitnessClasses",
                column: "ConceptId",
                principalTable: "FitnessConcepts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessClasses_FitnessLocations_LocationId",
                table: "FitnessClasses",
                column: "LocationId",
                principalTable: "FitnessLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessConcepts_FitnessCenters_FitnessCenterId",
                table: "FitnessConcepts",
                column: "FitnessCenterId",
                principalTable: "FitnessCenters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessConcepts_FitnessTrainers_TrainerId",
                table: "FitnessConcepts",
                column: "TrainerId",
                principalTable: "FitnessTrainers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCustomers_FitnessSubscriptions_SubscriptionName",
                table: "FitnessCustomers",
                column: "SubscriptionName",
                principalTable: "FitnessSubscriptions",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCustomers_FitnessTrainers_TrainerId",
                table: "FitnessCustomers",
                column: "TrainerId",
                principalTable: "FitnessTrainers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessLocations_FitnessCenters_CenterId",
                table: "FitnessLocations",
                column: "CenterId",
                principalTable: "FitnessCenters",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroupFitnessClass_FitnessClasses_BookedClassesId",
                table: "CustomerGroupFitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroupFitnessClass_FitnessCustomers_BookedParticipantsId",
                table: "CustomerGroupFitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCenters_FitnessAdmins_GymLeaderId",
                table: "FitnessCenters");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessClasses_FitnessConcepts_ConceptId",
                table: "FitnessClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessClasses_FitnessLocations_LocationId",
                table: "FitnessClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessConcepts_FitnessCenters_FitnessCenterId",
                table: "FitnessConcepts");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessConcepts_FitnessTrainers_TrainerId",
                table: "FitnessConcepts");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCustomers_FitnessSubscriptions_SubscriptionName",
                table: "FitnessCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCustomers_FitnessTrainers_TrainerId",
                table: "FitnessCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessLocations_FitnessCenters_CenterId",
                table: "FitnessLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupFitnessClassTrainer_FitnessClasses_ClassesByTrainerId",
                table: "GroupFitnessClassTrainer");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupFitnessClassTrainer_FitnessTrainers_InstructorsId",
                table: "GroupFitnessClassTrainer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessTrainers",
                table: "FitnessTrainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessSubscriptions",
                table: "FitnessSubscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessLocations",
                table: "FitnessLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCustomers",
                table: "FitnessCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessConcepts",
                table: "FitnessConcepts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessClasses",
                table: "FitnessClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessAdmins",
                table: "FitnessAdmins");

            migrationBuilder.RenameTable(
                name: "FitnessTrainers",
                newName: "Trainers");

            migrationBuilder.RenameTable(
                name: "FitnessSubscriptions",
                newName: "Subscriptions");

            migrationBuilder.RenameTable(
                name: "FitnessLocations",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "FitnessCustomers",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "FitnessConcepts",
                newName: "Classes");

            migrationBuilder.RenameTable(
                name: "FitnessClasses",
                newName: "GroupFitnessClass");

            migrationBuilder.RenameTable(
                name: "FitnessAdmins",
                newName: "Admins");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessTrainers_Email",
                table: "Trainers",
                newName: "IX_Trainers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessLocations_CenterId",
                table: "Locations",
                newName: "IX_Locations_CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomers_TrainerId",
                table: "Customers",
                newName: "IX_Customers_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomers_SubscriptionName",
                table: "Customers",
                newName: "IX_Customers_SubscriptionName");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomers_Email",
                table: "Customers",
                newName: "IX_Customers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessConcepts_TrainerId",
                table: "Classes",
                newName: "IX_Classes_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessConcepts_FitnessCenterId",
                table: "Classes",
                newName: "IX_Classes_FitnessCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessClasses_LocationId",
                table: "GroupFitnessClass",
                newName: "IX_GroupFitnessClass_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessClasses_ConceptId",
                table: "GroupFitnessClass",
                newName: "IX_GroupFitnessClass_ConceptId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessAdmins_Email",
                table: "Admins",
                newName: "IX_Admins_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupFitnessClass",
                table: "GroupFitnessClass",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_FitnessCenters_FitnessCenterId",
                table: "Classes",
                column: "FitnessCenterId",
                principalTable: "FitnessCenters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Trainers_TrainerId",
                table: "Classes",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroupFitnessClass_Customers_BookedParticipantsId",
                table: "CustomerGroupFitnessClass",
                column: "BookedParticipantsId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroupFitnessClass_GroupFitnessClass_BookedClassesId",
                table: "CustomerGroupFitnessClass",
                column: "BookedClassesId",
                principalTable: "GroupFitnessClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Subscriptions_SubscriptionName",
                table: "Customers",
                column: "SubscriptionName",
                principalTable: "Subscriptions",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Trainers_TrainerId",
                table: "Customers",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCenters_Admins_GymLeaderId",
                table: "FitnessCenters",
                column: "GymLeaderId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupFitnessClass_Classes_ConceptId",
                table: "GroupFitnessClass",
                column: "ConceptId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupFitnessClass_Locations_LocationId",
                table: "GroupFitnessClass",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupFitnessClassTrainer_GroupFitnessClass_ClassesByTrainerId",
                table: "GroupFitnessClassTrainer",
                column: "ClassesByTrainerId",
                principalTable: "GroupFitnessClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupFitnessClassTrainer_Trainers_InstructorsId",
                table: "GroupFitnessClassTrainer",
                column: "InstructorsId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_FitnessCenters_CenterId",
                table: "Locations",
                column: "CenterId",
                principalTable: "FitnessCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
