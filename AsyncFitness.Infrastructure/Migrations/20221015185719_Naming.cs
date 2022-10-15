using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class Naming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Instructors_TrainerEmail",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Trainers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Subscriptions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Trainers_TrainerEmail",
                table: "Customers",
                column: "TrainerEmail",
                principalTable: "Trainers",
                principalColumn: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Trainers_TrainerEmail",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "Instructors");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Instructors_TrainerEmail",
                table: "Customers",
                column: "TrainerEmail",
                principalTable: "Instructors",
                principalColumn: "Email");
        }
    }
}
