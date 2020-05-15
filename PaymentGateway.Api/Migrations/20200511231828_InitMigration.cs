using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGateway.Api.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PaymentGateway");

            migrationBuilder.CreateTable(
                name: "PaymentTransactionsHistory",
                schema: "PaymentGateway",
                columns: table => new
                {
                    Invoice = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CustomerId = table.Column<string>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReserveFunds = table.Column<bool>(nullable: false, defaultValue: false),
                    Tax = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Transaction_Detail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactionsHistory", x => x.Invoice);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                schema: "PaymentGateway",
                columns: table => new
                {
                    CustomerId = table.Column<string>(nullable: false),
                    AccountId = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ClientId = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Modified = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Secret = table.Column<string>(nullable: false),
                    PaymentGatewayUrl = table.Column<string>(nullable: false),
                    StoreUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTransactionsHistory",
                schema: "PaymentGateway");

            migrationBuilder.DropTable(
                name: "SystemSettings",
                schema: "PaymentGateway");
        }
    }
}
