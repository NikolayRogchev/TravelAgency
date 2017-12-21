using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TravelAgency.Data.Migrations
{
    public partial class DateDiff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Trips",
                nullable: false,
                computedColumnSql: "ABS(DATEDIFF(dd, [StartDate], [EndDate]))",
                oldClrType: typeof(TimeSpan),
                oldComputedColumnSql: "ABS(DATEDIFF(dd, [EndDate], [StartDate]))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Trips",
                nullable: false,
                computedColumnSql: "ABS(DATEDIFF(dd, [EndDate], [StartDate]))",
                oldClrType: typeof(TimeSpan),
                oldComputedColumnSql: "ABS(DATEDIFF(dd, [StartDate], [EndDate]))");
        }
    }
}
