using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class facilityclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GymLeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessCenters_Admins_GymLeaderId",
                        column: x => x.GymLeaderId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    FitnessCenterId = table.Column<int>(type: "int", nullable: true),
                    TrainerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_FitnessCenters_FitnessCenterId",
                        column: x => x.FitnessCenterId,
                        principalTable: "FitnessCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Classes_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_FitnessCenters_CenterId",
                        column: x => x.CenterId,
                        principalTable: "FitnessCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupFitnessClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ConceptId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFitnessClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupFitnessClass_Classes_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupFitnessClass_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroupFitnessClass",
                columns: table => new
                {
                    BookedClassesId = table.Column<int>(type: "int", nullable: false),
                    BookedParticipantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupFitnessClass", x => new { x.BookedClassesId, x.BookedParticipantsId });
                    table.ForeignKey(
                        name: "FK_CustomerGroupFitnessClass_Customers_BookedParticipantsId",
                        column: x => x.BookedParticipantsId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerGroupFitnessClass_GroupFitnessClass_BookedClassesId",
                        column: x => x.BookedClassesId,
                        principalTable: "GroupFitnessClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupFitnessClassTrainer",
                columns: table => new
                {
                    ClassesByTrainerId = table.Column<int>(type: "int", nullable: false),
                    InstructorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFitnessClassTrainer", x => new { x.ClassesByTrainerId, x.InstructorsId });
                    table.ForeignKey(
                        name: "FK_GroupFitnessClassTrainer_GroupFitnessClass_ClassesByTrainerId",
                        column: x => x.ClassesByTrainerId,
                        principalTable: "GroupFitnessClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupFitnessClassTrainer_Trainers_InstructorsId",
                        column: x => x.InstructorsId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_FitnessCenterId",
                table: "Classes",
                column: "FitnessCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TrainerId",
                table: "Classes",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroupFitnessClass_BookedParticipantsId",
                table: "CustomerGroupFitnessClass",
                column: "BookedParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessCenters_GymLeaderId",
                table: "FitnessCenters",
                column: "GymLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFitnessClass_ConceptId",
                table: "GroupFitnessClass",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFitnessClass_LocationId",
                table: "GroupFitnessClass",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFitnessClassTrainer_InstructorsId",
                table: "GroupFitnessClassTrainer",
                column: "InstructorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CenterId",
                table: "Locations",
                column: "CenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerGroupFitnessClass");

            migrationBuilder.DropTable(
                name: "GroupFitnessClassTrainer");

            migrationBuilder.DropTable(
                name: "GroupFitnessClass");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "FitnessCenters");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
