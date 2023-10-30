using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class discharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPACKOorRecovery",
                table: "OutlierOutQueue");

            migrationBuilder.AddColumn<string>(
                name: "ConsultantName",
                table: "PatientBed",
                type: "NVARCHAR(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentLocation",
                table: "PatientBed",
                type: "NVARCHAR(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "PatientBed",
                type: "NVARCHAR(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DischargeOutcome",
                table: "PatientBed",
                type: "NVARCHAR(500)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultantName",
                table: "PatientBed");

            migrationBuilder.DropColumn(
                name: "CurrentLocation",
                table: "PatientBed");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "PatientBed");

            migrationBuilder.DropColumn(
                name: "DischargeOutcome",
                table: "PatientBed");

            migrationBuilder.AddColumn<bool>(
                name: "IsPACKOorRecovery",
                table: "OutlierOutQueue",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
