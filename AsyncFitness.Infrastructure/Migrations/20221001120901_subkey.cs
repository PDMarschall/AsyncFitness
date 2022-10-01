using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class subkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymCustomers_Subscriptions_SubscriptionId",
                table: "GymCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_GymCustomers_SubscriptionId",
                table: "GymCustomers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "GymCustomers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SubscriptionName",
                table: "GymCustomers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_GymCustomers_SubscriptionName",
                table: "GymCustomers",
                column: "SubscriptionName");

            migrationBuilder.AddForeignKey(
                name: "FK_GymCustomers_Subscriptions_SubscriptionName",
                table: "GymCustomers",
                column: "SubscriptionName",
                principalTable: "Subscriptions",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymCustomers_Subscriptions_SubscriptionName",
                table: "GymCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_GymCustomers_SubscriptionName",
                table: "GymCustomers");

            migrationBuilder.DropColumn(
                name: "SubscriptionName",
                table: "GymCustomers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "GymCustomers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GymCustomers_SubscriptionId",
                table: "GymCustomers",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GymCustomers_Subscriptions_SubscriptionId",
                table: "GymCustomers",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");
        }
    }
}
