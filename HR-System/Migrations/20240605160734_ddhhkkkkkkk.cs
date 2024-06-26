using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_System.Migrations
{
    /// <inheritdoc />
    public partial class ddhhkkkkkkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSetting_Attendance_AttendanceId",
                table: "GeneralSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneralSetting_Employee_EmployeeId",
                table: "GeneralSetting");

            migrationBuilder.DropIndex(
                name: "IX_GeneralSetting_AttendanceId",
                table: "GeneralSetting");

            migrationBuilder.DropIndex(
                name: "IX_GeneralSetting_EmployeeId",
                table: "GeneralSetting");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "GeneralSetting");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "GeneralSetting");

            migrationBuilder.DropColumn(
                name: "Late",
                table: "GeneralSetting");

            migrationBuilder.DropColumn(
                name: "overtime",
                table: "GeneralSetting");

            migrationBuilder.DropColumn(
                name: "weekEnd1",
                table: "GeneralSetting");

            migrationBuilder.DropColumn(
                name: "weekEnd2",
                table: "GeneralSetting");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendanceId",
                table: "GeneralSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "GeneralSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Late",
                table: "GeneralSetting",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "overtime",
                table: "GeneralSetting",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "weekEnd1",
                table: "GeneralSetting",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "weekEnd2",
                table: "GeneralSetting",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSetting_AttendanceId",
                table: "GeneralSetting",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSetting_EmployeeId",
                table: "GeneralSetting",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralSetting_Attendance_AttendanceId",
                table: "GeneralSetting",
                column: "AttendanceId",
                principalTable: "Attendance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralSetting_Employee_EmployeeId",
                table: "GeneralSetting",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
