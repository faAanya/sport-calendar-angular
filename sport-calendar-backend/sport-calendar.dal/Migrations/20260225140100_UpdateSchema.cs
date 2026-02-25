using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sport_calendar.dal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workout_metrics");

            migrationBuilder.AddColumn<decimal>(
                name: "current_value",
                table: "workout_goals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "activity_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 4, "Push-ups" },
                    { 5, "Swimming" }
                });

            migrationBuilder.InsertData(
                table: "units",
                columns: new[] { "id", "unit_code" },
                values: new object[] { 4, "reps" });

            migrationBuilder.UpdateData(
                table: "workout_goals",
                keyColumn: "id",
                keyValue: 1,
                column: "current_value",
                value: 7500m);

            migrationBuilder.UpdateData(
                table: "workout_goals",
                keyColumn: "id",
                keyValue: 2,
                column: "current_value",
                value: 7.2m);

            migrationBuilder.UpdateData(
                table: "workout_goals",
                keyColumn: "id",
                keyValue: 3,
                column: "current_value",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "workout_goals",
                keyColumn: "id",
                keyValue: 4,
                column: "current_value",
                value: 12m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "activity_types",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "activity_types",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "units",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "current_value",
                table: "workout_goals");

            migrationBuilder.CreateTable(
                name: "workout_metrics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unit_id = table.Column<int>(type: "int", nullable: false),
                    workout_id = table.Column<int>(type: "int", nullable: false),
                    metric_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    recorded_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__workout___3213E83F752132BD", x => x.id);
                    table.ForeignKey(
                        name: "FK_Metrics_Unit",
                        column: x => x.unit_id,
                        principalTable: "units",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Metrics_Workout",
                        column: x => x.workout_id,
                        principalTable: "workouts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "workout_metrics",
                columns: new[] { "id", "metric_value", "unit_id", "workout_id" },
                values: new object[,]
                {
                    { 1, 2000m, 1, 1 },
                    { 2, 1.4m, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_workout_metrics_unit_id",
                table: "workout_metrics",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_workout_metrics_workout_id",
                table: "workout_metrics",
                column: "workout_id");
        }
    }
}
