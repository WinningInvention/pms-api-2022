using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aicu_Patient_Form_Details",
                columns: table => new
                {
                    Aicu_Patient_Form_Details_Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Id = table.Column<int>(type: "INT", nullable: false),
                    Consultant_Id = table.Column<int>(type: "INT", nullable: false),
                    Referring_Staff_Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Clinical_Requirement_Id = table.Column<int>(type: "INT", nullable: false),
                    Previous_Medical_Surgical_History = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Infection_Control_Information = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Referal_Date_Time = table.Column<DateTime>(type: "Datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aicuPatientFormDetailsMasterid", x => x.Aicu_Patient_Form_Details_Id);
                });

            migrationBuilder.CreateTable(
                name: "Bed",
                columns: table => new
                {
                    BedId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNumber = table.Column<int>(type: "INT", nullable: false),
                    ZoneId = table.Column<int>(type: "INT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_BedId", x => x.BedId);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Hospital_Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hospital_Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hospitalid", x => x.Hospital_Id);
                });

            migrationBuilder.CreateTable(
                name: "hospital_Ward_Location_Master",
                columns: table => new
                {
                    Hospital_Ward_Location_Master_Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wards_Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Hospital_Locatio_Id = table.Column<int>(type: "INT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hospitalWardLocationMasterid", x => x.Hospital_Ward_Location_Master_Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalLocationMaster",
                columns: table => new
                {
                    Location_Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hospital_Location = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hospitalLocationMasterid", x => x.Location_Id);
                });

            migrationBuilder.CreateTable(
                name: "OutlierQueue_In",
                columns: table => new
                {
                    OutlierQueue_In_Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Id = table.Column<int>(type: "INT", nullable: false),
                    Priority_Level_id = table.Column<int>(type: "INT", nullable: false),
                    Start_Datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outlierQueue_Inid", x => x.OutlierQueue_In_Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Patient_Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hospital_Number = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    NHS_Number = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Post_Code = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Age = table.Column<int>(type: "INT", nullable: false),
                    DOB = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Health_Board = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Repatriation = table.Column<bool>(type: "bit", nullable: false),
                    Hospital_Location_Id = table.Column<int>(type: "INT", nullable: false),
                    Another_Hospital = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Admitting_Consultant_Name_Id = table.Column<int>(type: "INT", nullable: false),
                    Organ_Support_Requirements = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    IsCardiff = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecialist = table.Column<bool>(type: "bit", nullable: false),
                    Speciality_Id = table.Column<int>(type: "INT", nullable: false),
                    Hospital_Id = table.Column<int>(type: "INT", nullable: false),
                    Provisional_Diagnosis = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Priority_Level_Id = table.Column<int>(type: "INT", nullable: false),
                    Ward_Location_ID = table.Column<int>(type: "INT", nullable: false),
                    Hospital_Ward_Location = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patientid", x => x.Patient_Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientBed",
                columns: table => new
                {
                    PatientBedId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "INT", nullable: false),
                    BedId = table.Column<int>(type: "INT", nullable: false),
                    AllocationDatetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    NurseId = table.Column<int>(type: "INT", nullable: false),
                    DischargeDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    PredictedDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDischarged = table.Column<bool>(type: "bit", nullable: false),
                    DischargeTypeId = table.Column<int>(type: "INT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_PatientBedId", x => x.PatientBedId);
                });

            migrationBuilder.CreateTable(
                name: "PatientBedTracking",
                columns: table => new
                {
                    PatientBedTrackingId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientBedId = table.Column<int>(type: "INT", nullable: false),
                    BedId = table.Column<int>(type: "INT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ PatientBedTrackingId", x => x.PatientBedTrackingId);
                });

            migrationBuilder.CreateTable(
                name: "PriorityLevelMaster",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority_Level = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_PriorityLevelMasterid", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "Referal",
                columns: table => new
                {
                    Referal_Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Id = table.Column<int>(type: "INT", nullable: false),
                    Referal_Status_Id = table.Column<int>(type: "INT", nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Start_Datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Referalid", x => x.Referal_Id);
                });

            migrationBuilder.CreateTable(
                name: "referal_status_Master",
                columns: table => new
                {
                    Referal_status_Master_id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_referal_StatusMasterid", x => x.Referal_status_Master_id);
                });

            migrationBuilder.CreateTable(
                name: "ReferalComment",
                columns: table => new
                {
                    ReferalCommentId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferalId = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ReferalCommentId", x => x.ReferalCommentId);
                });

            migrationBuilder.CreateTable(
                name: "Repatriation",
                columns: table => new
                {
                    RepatriationMap_Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Id = table.Column<int>(type: "INT", nullable: false),
                    Is_Repatriation = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_repatriationMapid", x => x.RepatriationMap_Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialityMaster",
                columns: table => new
                {
                    Speciality_id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speciality = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_SpecialityMasterid", x => x.Speciality_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    UserTypeId = table.Column<int>(type: "INT", nullable: false),
                    UserdDetails = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    EmailId = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    HospitlId = table.Column<int>(type: "INT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Userid", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    TotalBeds = table.Column<int>(type: "INT", nullable: false),
                    ZoneTypeId = table.Column<int>(type: "INT", nullable: false),
                    HospitalId = table.Column<int>(type: "INT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ZoneId", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "ZoneTypeMaster",
                columns: table => new
                {
                    ZoneTypeId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneType = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ZoneTypeMasterZoneTypeId", x => x.ZoneTypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aicu_Patient_Form_Details");

            migrationBuilder.DropTable(
                name: "Bed");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "hospital_Ward_Location_Master");

            migrationBuilder.DropTable(
                name: "HospitalLocationMaster");

            migrationBuilder.DropTable(
                name: "OutlierQueue_In");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "PatientBed");

            migrationBuilder.DropTable(
                name: "PatientBedTracking");

            migrationBuilder.DropTable(
                name: "PriorityLevelMaster");

            migrationBuilder.DropTable(
                name: "Referal");

            migrationBuilder.DropTable(
                name: "referal_status_Master");

            migrationBuilder.DropTable(
                name: "ReferalComment");

            migrationBuilder.DropTable(
                name: "Repatriation");

            migrationBuilder.DropTable(
                name: "SpecialityMaster");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "ZoneTypeMaster");
        }
    }
}
