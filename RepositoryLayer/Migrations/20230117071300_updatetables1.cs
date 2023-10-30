using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class updatetables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HospitalName",
                table: "Repatriation",
                newName: "RepatHospitalName");

            migrationBuilder.RenameColumn(
                name: "ConsultantName",
                table: "Repatriation",
                newName: "RepatConsultantName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepatHospitalName",
                table: "Repatriation",
                newName: "HospitalName");

            migrationBuilder.RenameColumn(
                name: "RepatConsultantName",
                table: "Repatriation",
                newName: "ConsultantName");
        }
    }
}
