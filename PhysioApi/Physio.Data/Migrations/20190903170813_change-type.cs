using Microsoft.EntityFrameworkCore.Migrations;

namespace Physio.Data.Migrations
{
    public partial class changetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ScheduleTime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ScheduleTime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ScheduleTime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "ScheduleTime",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Doctor",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Doctor",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ScheduleTime");

            migrationBuilder.DropColumn(
                name: "City",
                table: "ScheduleTime");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ScheduleTime");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "ScheduleTime");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNo",
                table: "Doctor",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Doctor",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
