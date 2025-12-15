using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoice_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cnpj_service_provider = table.Column<string>(type: "char(14)", nullable: false),
                    cnpj_taker = table.Column<string>(type: "char(14)", nullable: false),
                    date_issue = table.Column<DateOnly>(type: "date", nullable: false),
                    service_description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInvoices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceInvoices");
        }
    }
}
