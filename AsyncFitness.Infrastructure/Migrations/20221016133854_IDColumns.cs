using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class IDColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Subscriptions_SubscriptionName",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_TrainerId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_SubscriptionName",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TrainerId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SubscriptionName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Trainers");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "Trainers",
                newName: "IX_Trainers_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TrainerId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Subscriptions_SubscriptionName",
                        column: x => x.SubscriptionName,
                        principalTable: "Subscriptions",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Customers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SubscriptionName",
                table: "Customers",
                column: "SubscriptionName");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TrainerId",
                table: "Customers",
                column: "TrainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Trainers_Email",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionName",
                table: "User",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_SubscriptionName",
                table: "User",
                column: "SubscriptionName");

            migrationBuilder.CreateIndex(
                name: "IX_User_TrainerId",
                table: "User",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Subscriptions_SubscriptionName",
                table: "User",
                column: "SubscriptionName",
                principalTable: "Subscriptions",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_TrainerId",
                table: "User",
                column: "TrainerId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
