using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class PasswordAndEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GymCustomers",
                table: "GymCustomers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "GymCustomers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "GymCustomers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "GymCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymCustomers",
                table: "GymCustomers",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GymCustomers",
                table: "GymCustomers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "GymCustomers");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "GymCustomers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "GymCustomers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymCustomers",
                table: "GymCustomers",
                column: "Phone");
        }
    }
}
