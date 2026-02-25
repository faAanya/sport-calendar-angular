using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sport_calendar.dal.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTestSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "workout_goals",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "workout_goals",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "workout_goals",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "workout_goals",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "workouts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "workouts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "workouts",
                keyColumn: "id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "workouts",
                columns: new[] { "id", "activity_id", "status_id", "workout_date" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateOnly(2026, 2, 24) },
                    { 2, 2, 1, new DateOnly(2026, 2, 24) },
                    { 3, 3, 1, new DateOnly(2026, 2, 25) }
                });

            migrationBuilder.InsertData(
                table: "workout_goals",
                columns: new[] { "id", "current_value", "target_value", "unit_id", "workout_id" },
                values: new object[,]
                {
                    { 1, 7500m, 10000m, 1, 1 },
                    { 2, 7.2m, 7.5m, 2, 1 },
                    { 3, 0m, 5.0m, 2, 2 },
                    { 4, 12m, 45m, 3, 3 }
                });
        }
    }
}
