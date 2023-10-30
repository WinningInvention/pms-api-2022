using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class updatetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Infection_Control_Information",
                table: "Aicu_Patient_Form_Details");

            migrationBuilder.AddColumn<string>(
                name: "ConsultantName",
                table: "Repatriation",
                type: "NVARCHAR(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HospitalName",
                table: "Repatriation",
                type: "NVARCHAR(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RepatType",
                table: "Repatriation",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsReadyDischarge",
                table: "PatientBed",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProvisionalDiagnosisSecondary",
                table: "Patient",
                type: "NVARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InfectionControlID",
                table: "Aicu_Patient_Form_Details",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OtherIntectionControl",
                table: "Aicu_Patient_Form_Details",
                type: "NVARCHAR(500)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultantName",
                table: "Repatriation");

            migrationBuilder.DropColumn(
                name: "HospitalName",
                table: "Repatriation");

            migrationBuilder.DropColumn(
                name: "RepatType",
                table: "Repatriation");

            migrationBuilder.DropColumn(
                name: "IsReadyDischarge",
                table: "PatientBed");

            migrationBuilder.DropColumn(
                name: "ProvisionalDiagnosisSecondary",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "InfectionControlID",
                table: "Aicu_Patient_Form_Details");

            migrationBuilder.DropColumn(
                name: "OtherIntectionControl",
                table: "Aicu_Patient_Form_Details");

            migrationBuilder.AddColumn<string>(
                name: "Infection_Control_Information",
                table: "Aicu_Patient_Form_Details",
                type: "NVARCHAR(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
