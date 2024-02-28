using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientInformationPortal.Migrations
{
    /// <inheritdoc />
    public partial class Keys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PatientsInformation_DiseaseId",
                table: "PatientsInformation",
                column: "DiseaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_PatientsInfoId",
                table: "NCD_Details",
                column: "PatientsInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_PatientsInfoId",
                table: "Allergies_Details",
                column: "PatientsInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Details_PatientsInformation_PatientsInfoId",
                table: "Allergies_Details",
                column: "PatientsInfoId",
                principalTable: "PatientsInformation",
                principalColumn: "PatientsInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NCD_Details_PatientsInformation_PatientsInfoId",
                table: "NCD_Details",
                column: "PatientsInfoId",
                principalTable: "PatientsInformation",
                principalColumn: "PatientsInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsInformation_DiseaseInformation_DiseaseId",
                table: "PatientsInformation",
                column: "DiseaseId",
                principalTable: "DiseaseInformation",
                principalColumn: "DiseaseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Details_PatientsInformation_PatientsInfoId",
                table: "Allergies_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_NCD_Details_PatientsInformation_PatientsInfoId",
                table: "NCD_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientsInformation_DiseaseInformation_DiseaseId",
                table: "PatientsInformation");

            migrationBuilder.DropIndex(
                name: "IX_PatientsInformation_DiseaseId",
                table: "PatientsInformation");

            migrationBuilder.DropIndex(
                name: "IX_NCD_Details_PatientsInfoId",
                table: "NCD_Details");

            migrationBuilder.DropIndex(
                name: "IX_Allergies_Details_PatientsInfoId",
                table: "Allergies_Details");
        }
    }
}
