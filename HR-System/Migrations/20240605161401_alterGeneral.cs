using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_System.Migrations
{
    /// <inheritdoc />
    public partial class alterGeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstWeekEnd",
                table: "GeneralSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Late",
                table: "GeneralSetting",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "OverTime",
                table: "GeneralSetting",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "SecondWeekEnd",
                table: "GeneralSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstWeekEnd",
                table: "GeneralSetting");

            migrationBuilder.DropColumn(
                name: "Late",
                table: "GeneralSetting");

            migrationBuilder.DropColumn(
                name: "OverTime",
                table: "GeneralSetting");

            migrationBuilder.DropColumn(
                name: "SecondWeekEnd",
                table: "GeneralSetting");
        }
    }
}
