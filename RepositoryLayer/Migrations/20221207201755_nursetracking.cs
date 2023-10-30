using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class nursetracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NurseAvailabilityTracking",
                columns: table => new
                {
                    NurseAvailabilityTrackingId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseAvailablityId = table.Column<int>(type: "INT", nullable: false),
                    AvailabilityDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FirstShift = table.Column<int>(type: "INT", nullable: false),
                    SecondShift = table.Column<int>(type: "INT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_NurseAvailabilityTrackingId", x => x.NurseAvailabilityTrackingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NurseAvailabilityTracking");
        }
    }
}
