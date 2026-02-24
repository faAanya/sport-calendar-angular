using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sport_calendar.dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activity_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__activity__3213E83F71BBA419", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_label = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__statuses__3213E83F30F9A01E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unit_code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__units__3213E83F59CECF32", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workouts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workout_date = table.Column<DateOnly>(type: "date", nullable: false),
                    activity_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__workouts__3213E83FE82A5192", x => x.id);
                    table.ForeignKey(
                        name: "FK_Workouts_Activity",
                        column: x => x.activity_id,
                        principalTable: "activity_types",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Workouts_Status",
                        column: x => x.status_id,
                        principalTable: "statuses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "workout_goals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workout_id = table.Column<int>(type: "int", nullable: false),
                    unit_id = table.Column<int>(type: "int", nullable: false),
                    target_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__workout___3213E83F9E883FD9", x => x.id);
                    table.ForeignKey(
                        name: "FK_Goals_Unit",
                        column: x => x.unit_id,
                        principalTable: "units",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Goals_Workout",
                        column: x => x.workout_id,
                        principalTable: "workouts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workout_metrics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workout_id = table.Column<int>(type: "int", nullable: false),
                    unit_id = table.Column<int>(type: "int", nullable: false),
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
                table: "activity_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Walking" },
                    { 2, "Running" },
                    { 3, "Cycling" }
                });

            migrationBuilder.InsertData(
                table: "statuses",
                columns: new[] { "id", "status_label" },
                values: new object[,]
                {
                    { 1, "Planned" },
                    { 2, "In Progress" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "units",
                columns: new[] { "id", "unit_code" },
                values: new object[,]
                {
                    { 1, "steps" },
                    { 2, "km" },
                    { 3, "min" }
                });

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
                columns: new[] { "id", "target_value", "unit_id", "workout_id" },
                values: new object[,]
                {
                    { 1, 10000m, 1, 1 },
                    { 2, 7.5m, 2, 1 },
                    { 3, 5.0m, 2, 2 },
                    { 4, 45m, 3, 3 }
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
                name: "IX_workout_goals_unit_id",
                table: "workout_goals",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_workout_goals_workout_id",
                table: "workout_goals",
                column: "workout_id");

            migrationBuilder.CreateIndex(
                name: "IX_workout_metrics_unit_id",
                table: "workout_metrics",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_workout_metrics_workout_id",
                table: "workout_metrics",
                column: "workout_id");

            migrationBuilder.CreateIndex(
                name: "IX_workouts_activity_id",
                table: "workouts",
                column: "activity_id");

            migrationBuilder.CreateIndex(
                name: "IX_workouts_status_id",
                table: "workouts",
                column: "status_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workout_goals");

            migrationBuilder.DropTable(
                name: "workout_metrics");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "workouts");

            migrationBuilder.DropTable(
                name: "activity_types");

            migrationBuilder.DropTable(
                name: "statuses");
        }
    }
}
