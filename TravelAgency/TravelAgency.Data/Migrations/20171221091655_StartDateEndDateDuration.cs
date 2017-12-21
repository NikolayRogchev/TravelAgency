using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TravelAgency.Data.Migrations
{
    public partial class StartDateEndDateDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Trips",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Trips",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Trips",
                nullable: false,
                computedColumnSql: "DATEDIFF(dd, [EndDate], [StartDate])",
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Trips");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldComputedColumnSql: "DATEDIFF(dd, [EndDate], [StartDate])");
        }
    }
}
