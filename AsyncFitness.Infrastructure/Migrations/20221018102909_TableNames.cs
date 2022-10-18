using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class TableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCenterConcepts_FitnessCenters_CentersWithConceptId",
                table: "FitnessCenterConcepts");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCenterConcepts_FitnessConcepts_AvailableConceptsId",
                table: "FitnessCenterConcepts");

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
                name: "FK_FitnessConcepts_FitnessTrainers_TrainerId",
                table: "FitnessConcepts");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCustomerClassBookings_FitnessClasses_BookedClassesId",
                table: "FitnessCustomerClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCustomerClassBookings_FitnessCustomers_BookedParticipantsId",
                table: "FitnessCustomerClassBookings");

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
                name: "FK_FitnessTrainerClassBookings_FitnessClasses_ClassesByTrainerId",
                table: "FitnessTrainerClassBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessTrainerClassBookings_FitnessTrainers_InstructorsId",
                table: "FitnessTrainerClassBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessTrainers",
                table: "FitnessTrainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessTrainerClassBookings",
                table: "FitnessTrainerClassBookings");

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
                name: "PK_FitnessCustomerClassBookings",
                table: "FitnessCustomerClassBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessConcepts",
                table: "FitnessConcepts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessClasses",
                table: "FitnessClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCenters",
                table: "FitnessCenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCenterConcepts",
                table: "FitnessCenterConcepts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessAdmins",
                table: "FitnessAdmins");

            migrationBuilder.RenameTable(
                name: "FitnessTrainers",
                newName: "FitnessTrainer");

            migrationBuilder.RenameTable(
                name: "FitnessTrainerClassBookings",
                newName: "FitnessTrainerClassBooking");

            migrationBuilder.RenameTable(
                name: "FitnessSubscriptions",
                newName: "FitnessSubscription");

            migrationBuilder.RenameTable(
                name: "FitnessLocations",
                newName: "FitnessLocation");

            migrationBuilder.RenameTable(
                name: "FitnessCustomers",
                newName: "FitnessCustomer");

            migrationBuilder.RenameTable(
                name: "FitnessCustomerClassBookings",
                newName: "FitnessCustomerClassBooking");

            migrationBuilder.RenameTable(
                name: "FitnessConcepts",
                newName: "FitnessConcept");

            migrationBuilder.RenameTable(
                name: "FitnessClasses",
                newName: "FitnessClass");

            migrationBuilder.RenameTable(
                name: "FitnessCenters",
                newName: "FitnessCenter");

            migrationBuilder.RenameTable(
                name: "FitnessCenterConcepts",
                newName: "FitnessConceptsAtCenter");

            migrationBuilder.RenameTable(
                name: "FitnessAdmins",
                newName: "FitnessAdmin");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessTrainers_Email",
                table: "FitnessTrainer",
                newName: "IX_FitnessTrainer_Email");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessTrainerClassBookings_InstructorsId",
                table: "FitnessTrainerClassBooking",
                newName: "IX_FitnessTrainerClassBooking_InstructorsId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessLocations_CenterId",
                table: "FitnessLocation",
                newName: "IX_FitnessLocation_CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomers_TrainerId",
                table: "FitnessCustomer",
                newName: "IX_FitnessCustomer_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomers_SubscriptionName",
                table: "FitnessCustomer",
                newName: "IX_FitnessCustomer_SubscriptionName");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomers_Email",
                table: "FitnessCustomer",
                newName: "IX_FitnessCustomer_Email");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomerClassBookings_BookedParticipantsId",
                table: "FitnessCustomerClassBooking",
                newName: "IX_FitnessCustomerClassBooking_BookedParticipantsId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessConcepts_TrainerId",
                table: "FitnessConcept",
                newName: "IX_FitnessConcept_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessClasses_LocationId",
                table: "FitnessClass",
                newName: "IX_FitnessClass_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessClasses_ConceptId",
                table: "FitnessClass",
                newName: "IX_FitnessClass_ConceptId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCenters_GymLeaderId",
                table: "FitnessCenter",
                newName: "IX_FitnessCenter_GymLeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCenterConcepts_CentersWithConceptId",
                table: "FitnessConceptsAtCenter",
                newName: "IX_FitnessConceptsAtCenter_CentersWithConceptId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessAdmins_Email",
                table: "FitnessAdmin",
                newName: "IX_FitnessAdmin_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessTrainer",
                table: "FitnessTrainer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessTrainerClassBooking",
                table: "FitnessTrainerClassBooking",
                columns: new[] { "ClassesByTrainerId", "InstructorsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessSubscription",
                table: "FitnessSubscription",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessLocation",
                table: "FitnessLocation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCustomer",
                table: "FitnessCustomer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCustomerClassBooking",
                table: "FitnessCustomerClassBooking",
                columns: new[] { "BookedClassesId", "BookedParticipantsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessConcept",
                table: "FitnessConcept",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessClass",
                table: "FitnessClass",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCenter",
                table: "FitnessCenter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessConceptsAtCenter",
                table: "FitnessConceptsAtCenter",
                columns: new[] { "AvailableConceptsId", "CentersWithConceptId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessAdmin",
                table: "FitnessAdmin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCenter_FitnessAdmin_GymLeaderId",
                table: "FitnessCenter",
                column: "GymLeaderId",
                principalTable: "FitnessAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessClass_FitnessConcept_ConceptId",
                table: "FitnessClass",
                column: "ConceptId",
                principalTable: "FitnessConcept",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessClass_FitnessLocation_LocationId",
                table: "FitnessClass",
                column: "LocationId",
                principalTable: "FitnessLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessConcept_FitnessTrainer_TrainerId",
                table: "FitnessConcept",
                column: "TrainerId",
                principalTable: "FitnessTrainer",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCustomer_FitnessSubscription_SubscriptionName",
                table: "FitnessCustomer",
                column: "SubscriptionName",
                principalTable: "FitnessSubscription",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCustomer_FitnessTrainer_TrainerId",
                table: "FitnessCustomer",
                column: "TrainerId",
                principalTable: "FitnessTrainer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCustomerClassBooking_FitnessClass_BookedClassesId",
                table: "FitnessCustomerClassBooking",
                column: "BookedClassesId",
                principalTable: "FitnessClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCustomerClassBooking_FitnessCustomer_BookedParticipantsId",
                table: "FitnessCustomerClassBooking",
                column: "BookedParticipantsId",
                principalTable: "FitnessCustomer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessLocation_FitnessCenter_CenterId",
                table: "FitnessLocation",
                column: "CenterId",
                principalTable: "FitnessCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessTrainerClassBooking_FitnessClass_ClassesByTrainerId",
                table: "FitnessTrainerClassBooking",
                column: "ClassesByTrainerId",
                principalTable: "FitnessClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessTrainerClassBooking_FitnessTrainer_InstructorsId",
                table: "FitnessTrainerClassBooking",
                column: "InstructorsId",
                principalTable: "FitnessTrainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCenter_FitnessAdmin_GymLeaderId",
                table: "FitnessCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessClass_FitnessConcept_ConceptId",
                table: "FitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessClass_FitnessLocation_LocationId",
                table: "FitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessConcept_FitnessTrainer_TrainerId",
                table: "FitnessConcept");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessConceptsAtCenter_FitnessCenter_CentersWithConceptId",
                table: "FitnessConceptsAtCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessConceptsAtCenter_FitnessConcept_AvailableConceptsId",
                table: "FitnessConceptsAtCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCustomer_FitnessSubscription_SubscriptionName",
                table: "FitnessCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCustomer_FitnessTrainer_TrainerId",
                table: "FitnessCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCustomerClassBooking_FitnessClass_BookedClassesId",
                table: "FitnessCustomerClassBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessCustomerClassBooking_FitnessCustomer_BookedParticipantsId",
                table: "FitnessCustomerClassBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessLocation_FitnessCenter_CenterId",
                table: "FitnessLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessTrainerClassBooking_FitnessClass_ClassesByTrainerId",
                table: "FitnessTrainerClassBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessTrainerClassBooking_FitnessTrainer_InstructorsId",
                table: "FitnessTrainerClassBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessTrainerClassBooking",
                table: "FitnessTrainerClassBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessTrainer",
                table: "FitnessTrainer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessSubscription",
                table: "FitnessSubscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessLocation",
                table: "FitnessLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCustomerClassBooking",
                table: "FitnessCustomerClassBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCustomer",
                table: "FitnessCustomer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessConceptsAtCenter",
                table: "FitnessConceptsAtCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessConcept",
                table: "FitnessConcept");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessClass",
                table: "FitnessClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessCenter",
                table: "FitnessCenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FitnessAdmin",
                table: "FitnessAdmin");

            migrationBuilder.RenameTable(
                name: "FitnessTrainerClassBooking",
                newName: "FitnessTrainerClassBookings");

            migrationBuilder.RenameTable(
                name: "FitnessTrainer",
                newName: "FitnessTrainers");

            migrationBuilder.RenameTable(
                name: "FitnessSubscription",
                newName: "FitnessSubscriptions");

            migrationBuilder.RenameTable(
                name: "FitnessLocation",
                newName: "FitnessLocations");

            migrationBuilder.RenameTable(
                name: "FitnessCustomerClassBooking",
                newName: "FitnessCustomerClassBookings");

            migrationBuilder.RenameTable(
                name: "FitnessCustomer",
                newName: "FitnessCustomers");

            migrationBuilder.RenameTable(
                name: "FitnessConceptsAtCenter",
                newName: "FitnessCenterConcepts");

            migrationBuilder.RenameTable(
                name: "FitnessConcept",
                newName: "FitnessConcepts");

            migrationBuilder.RenameTable(
                name: "FitnessClass",
                newName: "FitnessClasses");

            migrationBuilder.RenameTable(
                name: "FitnessCenter",
                newName: "FitnessCenters");

            migrationBuilder.RenameTable(
                name: "FitnessAdmin",
                newName: "FitnessAdmins");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessTrainerClassBooking_InstructorsId",
                table: "FitnessTrainerClassBookings",
                newName: "IX_FitnessTrainerClassBookings_InstructorsId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessTrainer_Email",
                table: "FitnessTrainers",
                newName: "IX_FitnessTrainers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessLocation_CenterId",
                table: "FitnessLocations",
                newName: "IX_FitnessLocations_CenterId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomerClassBooking_BookedParticipantsId",
                table: "FitnessCustomerClassBookings",
                newName: "IX_FitnessCustomerClassBookings_BookedParticipantsId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomer_TrainerId",
                table: "FitnessCustomers",
                newName: "IX_FitnessCustomers_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomer_SubscriptionName",
                table: "FitnessCustomers",
                newName: "IX_FitnessCustomers_SubscriptionName");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCustomer_Email",
                table: "FitnessCustomers",
                newName: "IX_FitnessCustomers_Email");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessConceptsAtCenter_CentersWithConceptId",
                table: "FitnessCenterConcepts",
                newName: "IX_FitnessCenterConcepts_CentersWithConceptId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessConcept_TrainerId",
                table: "FitnessConcepts",
                newName: "IX_FitnessConcepts_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessClass_LocationId",
                table: "FitnessClasses",
                newName: "IX_FitnessClasses_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessClass_ConceptId",
                table: "FitnessClasses",
                newName: "IX_FitnessClasses_ConceptId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessCenter_GymLeaderId",
                table: "FitnessCenters",
                newName: "IX_FitnessCenters_GymLeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessAdmin_Email",
                table: "FitnessAdmins",
                newName: "IX_FitnessAdmins_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessTrainerClassBookings",
                table: "FitnessTrainerClassBookings",
                columns: new[] { "ClassesByTrainerId", "InstructorsId" });

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
                name: "PK_FitnessCustomerClassBookings",
                table: "FitnessCustomerClassBookings",
                columns: new[] { "BookedClassesId", "BookedParticipantsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCustomers",
                table: "FitnessCustomers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCenterConcepts",
                table: "FitnessCenterConcepts",
                columns: new[] { "AvailableConceptsId", "CentersWithConceptId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessConcepts",
                table: "FitnessConcepts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessClasses",
                table: "FitnessClasses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessCenters",
                table: "FitnessCenters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FitnessAdmins",
                table: "FitnessAdmins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCenterConcepts_FitnessCenters_CentersWithConceptId",
                table: "FitnessCenterConcepts",
                column: "CentersWithConceptId",
                principalTable: "FitnessCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessCenterConcepts_FitnessConcepts_AvailableConceptsId",
                table: "FitnessCenterConcepts",
                column: "AvailableConceptsId",
                principalTable: "FitnessConcepts",
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
                name: "FK_FitnessConcepts_FitnessTrainers_TrainerId",
                table: "FitnessConcepts",
                column: "TrainerId",
                principalTable: "FitnessTrainers",
                principalColumn: "Id");

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
    }
}
