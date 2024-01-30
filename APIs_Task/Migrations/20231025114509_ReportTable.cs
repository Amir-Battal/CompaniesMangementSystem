using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs_Task.Migrations
{
    /// <inheritdoc />
    public partial class ReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Reportfrom",
                table: "creates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Reportto",
                table: "creates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    from = table.Column<DateTime>(type: "datetime2", nullable: false),
                    to = table.Column<DateTime>(type: "datetime2", nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    branchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => new { x.from, x.to });
                });

            migrationBuilder.CreateIndex(
                name: "IX_creates_Reportfrom_Reportto",
                table: "creates",
                columns: new[] { "Reportfrom", "Reportto" });

            migrationBuilder.AddForeignKey(
                name: "FK_creates_reports_Reportfrom_Reportto",
                table: "creates",
                columns: new[] { "Reportfrom", "Reportto" },
                principalTable: "reports",
                principalColumns: new[] { "from", "to" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_creates_reports_Reportfrom_Reportto",
                table: "creates");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropIndex(
                name: "IX_creates_Reportfrom_Reportto",
                table: "creates");

            migrationBuilder.DropColumn(
                name: "Reportfrom",
                table: "creates");

            migrationBuilder.DropColumn(
                name: "Reportto",
                table: "creates");
        }
    }
}
