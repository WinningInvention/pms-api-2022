﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

#nullable disable

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221207201755_nursetracking")]
    partial class nursetracking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DomainLayer.Models.Aicu_Patient_Form_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Aicu_Patient_Form_Details_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Clinical_Requirement_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Clinical_Requirement_Id");

                    b.Property<int>("Consultant_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Consultant_Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Infection_Control_Information")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Infection_Control_Information");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Patient_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Patient_Id");

                    b.Property<string>("Previous_Medical_Surgical_History")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Previous_Medical_Surgical_History");

                    b.Property<DateTime>("Referal_Date_Time")
                        .HasColumnType("Datetime")
                        .HasColumnName("Referal_Date_Time");

                    b.Property<string>("Referring_Staff_Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Referring_Staff_Name");

                    b.HasKey("Id")
                        .HasName("pk_aicuPatientFormDetailsMasterid");

                    b.ToTable("Aicu_Patient_Form_Details");
                });

            modelBuilder.Entity("DomainLayer.Models.Bed", b =>
                {
                    b.Property<int>("BedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("BedId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BedId"), 1L, 1);

                    b.Property<int>("BedNumber")
                        .HasColumnType("INT")
                        .HasColumnName("BedNumber");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ZoneId")
                        .HasColumnType("INT")
                        .HasColumnName("ZoneId");

                    b.HasKey("BedId")
                        .HasName("pk_BedId");

                    b.ToTable("Bed");
                });

            modelBuilder.Entity("DomainLayer.Models.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Hospital_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Created_Date");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Hospital_Name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Active");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("Modified_Date");

                    b.HasKey("Id")
                        .HasName("pk_hospitalid");

                    b.ToTable("Hospital");
                });

            modelBuilder.Entity("DomainLayer.Models.hospital_Ward_Location_Master", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Hospital_Ward_Location_Master_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hospital_Locatio_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Hospital_Locatio_Id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Wards_Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Wards_Name");

                    b.HasKey("Id")
                        .HasName("pk_hospitalWardLocationMasterid");

                    b.ToTable("hospital_Ward_Location_Master");
                });

            modelBuilder.Entity("DomainLayer.Models.HospitalLocationMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Location_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hospital_Location")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Hospital_Location");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("pk_hospitalLocationMasterid");

                    b.ToTable("HospitalLocationMaster");
                });

            modelBuilder.Entity("DomainLayer.Models.NurseAvailability", b =>
                {
                    b.Property<int>("NurseAvailablityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("NurseAvailabilityId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NurseAvailablityId"), 1L, 1);

                    b.Property<DateTime>("AvailabilityDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("AvailabilityDate");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FirstShift")
                        .HasColumnType("INT")
                        .HasColumnName("FirstShift");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SecondShift")
                        .HasColumnType("INT")
                        .HasColumnName("SecondShift");

                    b.HasKey("NurseAvailablityId")
                        .HasName("pk_NurseAvailabilityId");

                    b.ToTable("NurseAvailability");
                });

            modelBuilder.Entity("DomainLayer.Models.NurseAvailabilityTracking", b =>
                {
                    b.Property<int>("NurseAvailabilityTrackingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("NurseAvailabilityTrackingId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NurseAvailabilityTrackingId"), 1L, 1);

                    b.Property<DateTime>("AvailabilityDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("AvailabilityDate");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FirstShift")
                        .HasColumnType("INT")
                        .HasColumnName("FirstShift");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NurseAvailablityId")
                        .HasColumnType("INT")
                        .HasColumnName("NurseAvailablityId");

                    b.Property<int>("SecondShift")
                        .HasColumnType("INT")
                        .HasColumnName("SecondShift");

                    b.HasKey("NurseAvailabilityTrackingId")
                        .HasName("pk_NurseAvailabilityTrackingId");

                    b.ToTable("NurseAvailabilityTracking");
                });

            modelBuilder.Entity("DomainLayer.Models.OutlierQueue_In", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("OutlierQueue_In_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Patient_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Patient_Id");

                    b.Property<int>("Priority_Level_id")
                        .HasColumnType("INT")
                        .HasColumnName("Priority_Level_id");

                    b.Property<DateTime>("Start_Datetime")
                        .HasColumnType("datetime")
                        .HasColumnName("Start_Datetime");

                    b.HasKey("Id")
                        .HasName("pk_outlierQueue_Inid");

                    b.ToTable("OutlierQueue_In");
                });

            modelBuilder.Entity("DomainLayer.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Patient_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Admitting_consultant_name_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Admitting_Consultant_Name_Id");

                    b.Property<int>("Age")
                        .HasColumnType("INT")
                        .HasColumnName("Age");

                    b.Property<string>("Another_Hospital")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Another_Hospital");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("DateTime")
                        .HasColumnName("DOB");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Gender");

                    b.Property<int>("Hospital_Location_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Hospital_Location_Id");

                    b.Property<string>("Hospital_Number")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Hospital_Number");

                    b.Property<string>("Hospital_Ward_Location")
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Hospital_Ward_Location");

                    b.Property<int>("Hospital_id")
                        .HasColumnType("INT")
                        .HasColumnName("Hospital_Id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCardiff")
                        .HasColumnType("bit")
                        .HasColumnName("IsCardiff");

                    b.Property<bool>("IsSpecialist")
                        .HasColumnType("bit")
                        .HasColumnName("IsSpecialist");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NHS_Number")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("NHS_Number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Organ_Support_requirements")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Organ_Support_Requirements");

                    b.Property<string>("Post_Code")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Post_Code");

                    b.Property<int>("Priority_Level_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Priority_Level_Id");

                    b.Property<string>("Provisional_diagnosis")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Provisional_Diagnosis");

                    b.Property<bool>("Repatriation")
                        .HasColumnType("bit")
                        .HasColumnName("Repatriation");

                    b.Property<int>("Speciality_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Speciality_Id");

                    b.Property<int>("Ward_Location_ID")
                        .HasColumnType("INT")
                        .HasColumnName("Ward_Location_ID");

                    b.Property<string>("health_board")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Health_Board");

                    b.HasKey("Id")
                        .HasName("pk_patientid");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("DomainLayer.Models.PatientBed", b =>
                {
                    b.Property<int>("PatientBedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("PatientBedId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientBedId"), 1L, 1);

                    b.Property<DateTime>("AllocationDatetime")
                        .HasColumnType("datetime")
                        .HasColumnName("AllocationDatetime");

                    b.Property<int>("BedId")
                        .HasColumnType("INT")
                        .HasColumnName("BedId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DischargeDatetime")
                        .HasColumnType("datetime")
                        .HasColumnName("DischargeDatetime");

                    b.Property<int>("DischargeTypeId")
                        .HasColumnType("INT")
                        .HasColumnName("DischargeTypeId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDischarged")
                        .HasColumnType("bit")
                        .HasColumnName("IsDischarged");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NurseId")
                        .HasColumnType("INT")
                        .HasColumnName("NurseId");

                    b.Property<int>("PatientId")
                        .HasColumnType("INT")
                        .HasColumnName("PatientId");

                    b.Property<DateTime?>("PredictedDatetime")
                        .HasColumnType("datetime")
                        .HasColumnName("PredictedDatetime");

                    b.HasKey("PatientBedId")
                        .HasName("pk_PatientBedId");

                    b.ToTable("PatientBed");
                });

            modelBuilder.Entity("DomainLayer.Models.PatientBedTracking", b =>
                {
                    b.Property<int>("PatientBedTrackingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("PatientBedTrackingId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientBedTrackingId"), 1L, 1);

                    b.Property<int>("BedId")
                        .HasColumnType("INT")
                        .HasColumnName("BedId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientBedId")
                        .HasColumnType("INT")
                        .HasColumnName("PatientBedId");

                    b.HasKey("PatientBedTrackingId")
                        .HasName("pk_ PatientBedTrackingId");

                    b.ToTable("PatientBedTracking");
                });

            modelBuilder.Entity("DomainLayer.Models.PriorityLevelMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("LevelId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Priority_Level")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Priority_Level");

                    b.HasKey("Id")
                        .HasName("pk_PriorityLevelMasterid");

                    b.ToTable("PriorityLevelMaster");
                });

            modelBuilder.Entity("DomainLayer.Models.Referal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Referal_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Comment");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Patient_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Patient_Id");

                    b.Property<int>("Referal_Status_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Referal_Status_Id");

                    b.Property<DateTime>("Start_Datetime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("pk_Referalid");

                    b.ToTable("Referal");
                });

            modelBuilder.Entity("DomainLayer.Models.referal_status_Master", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Referal_status_Master_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Status");

                    b.HasKey("Id")
                        .HasName("pk_referal_StatusMasterid");

                    b.ToTable("referal_status_Master");
                });

            modelBuilder.Entity("DomainLayer.Models.ReferalComment", b =>
                {
                    b.Property<int>("ReferalCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ReferalCommentId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReferalCommentId"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(250)")
                        .HasColumnName("Comment");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferalId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("ReferalId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(250)")
                        .HasColumnName("UserName");

                    b.HasKey("ReferalCommentId")
                        .HasName("pk_ReferalCommentId");

                    b.ToTable("ReferalComment");
                });

            modelBuilder.Entity("DomainLayer.Models.Repatriation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("RepatriationMap_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_Repatriation")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Patient_Id")
                        .HasColumnType("INT")
                        .HasColumnName("Patient_Id");

                    b.HasKey("Id")
                        .HasName("pk_repatriationMapid");

                    b.ToTable("Repatriation");
                });

            modelBuilder.Entity("DomainLayer.Models.SpecialityMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("Speciality_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Speciality");

                    b.HasKey("Id")
                        .HasName("pk_SpecialityMasterid");

                    b.ToTable("SpecialityMaster");
                });

            modelBuilder.Entity("DomainLayer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("User_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("EmailId");

                    b.Property<int>("HospitlId")
                        .HasColumnType("INT")
                        .HasColumnName("HospitlId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("UserName");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("INT")
                        .HasColumnName("UserTypeId");

                    b.Property<string>("UserdDetails")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("UserdDetails");

                    b.HasKey("Id")
                        .HasName("pk_Userid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DomainLayer.Models.Zone", b =>
                {
                    b.Property<int>("ZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ZoneId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZoneId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HospitalId")
                        .HasColumnType("INT")
                        .HasColumnName("HospitalId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalBeds")
                        .HasColumnType("INT")
                        .HasColumnName("TotalBeds");

                    b.Property<string>("ZoneName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("ZoneName");

                    b.Property<int>("ZoneTypeId")
                        .HasColumnType("INT")
                        .HasColumnName("ZoneTypeId");

                    b.HasKey("ZoneId")
                        .HasName("pk_ZoneId");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("DomainLayer.Models.ZoneTypeMaster", b =>
                {
                    b.Property<int>("ZoneTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ZoneTypeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZoneTypeId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZoneType")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("ZoneType");

                    b.HasKey("ZoneTypeId")
                        .HasName("pk_ZoneTypeMasterZoneTypeId");

                    b.ToTable("ZoneTypeMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
