using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    public partial class NullSub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Subscriptions_SubscriptionName",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "SubscriptionName",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Subscriptions_SubscriptionName",
                table: "Customers",
                column: "SubscriptionName",
                principalTable: "Subscriptions",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Subscriptions_SubscriptionName",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "SubscriptionName",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Subscriptions_SubscriptionName",
                table: "Customers",
                column: "SubscriptionName",
                principalTable: "Subscriptions",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
