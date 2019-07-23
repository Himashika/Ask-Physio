using Microsoft.EntityFrameworkCore.Migrations;

namespace Physio.Data.Migrations
{
    public partial class RemeverelationsOnappoiment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Appoiment_Doctor_DoctorId",
            //    table: "Appoiment");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Appoiment_Patient_PatientId",
            //    table: "Appoiment");

            //migrationBuilder.DropIndex(
            //    name: "IX_Appoiment_DoctorId",
            //    table: "Appoiment");

            //migrationBuilder.DropIndex(
            //    name: "IX_Appoiment_PatientId",
            //    table: "Appoiment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appoiment_DoctorId",
                table: "Appoiment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appoiment_PatientId",
                table: "Appoiment",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appoiment_Doctor_DoctorId",
                table: "Appoiment",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appoiment_Patient_PatientId",
                table: "Appoiment",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
