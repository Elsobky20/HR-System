using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_System.Migrations
{
    /// <inheritdoc />
    public partial class vg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficialVacation_Attendance_AttendanceId",
                table: "OfficialVacation");

            migrationBuilder.DropIndex(
                name: "IX_OfficialVacation_AttendanceId",
                table: "OfficialVacation");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "OfficialVacation");

            migrationBuilder.AddColumn<string>(
                name: "VacationName",
                table: "OfficialVacation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VacationName",
                table: "OfficialVacation");

            migrationBuilder.AddColumn<int>(
                name: "AttendanceId",
                table: "OfficialVacation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OfficialVacation_AttendanceId",
                table: "OfficialVacation",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialVacation_Attendance_AttendanceId",
                table: "OfficialVacation",
                column: "AttendanceId",
                principalTable: "Attendance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
