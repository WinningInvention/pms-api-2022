using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMapper
{
    public class PatientMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_patientid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("Patient_Id")
                .HasColumnType("INT");
            builder.Property(x => x.Hospital_Number)
                .HasColumnName("Hospital_Number")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.NHS_Number)
                .HasColumnName("NHS_Number")
                .HasColumnType("NVARCHAR(100)");
            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.Post_Code)
                .HasColumnName("Post_Code")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.Age)
                .HasColumnName("Age")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.DOB)
                .HasColumnName("DOB")
                .HasColumnType("DateTime")
                .IsRequired();
            builder.Property(x => x.Organ_Support_requirements)
               .HasColumnName("Organ_Support_Requirements")
               .HasColumnType("NVARCHAR(100)")
               .IsRequired();
            builder.Property(x => x.Gender)
                .HasColumnName("Gender")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.health_board)
                .HasColumnName("Health_Board")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.Repatriation)
                .HasColumnName("Repatriation")
                .HasColumnType("bit")
                .IsRequired();
            builder.Property(x => x.Hospital_Location_Id)
                .HasColumnName("Hospital_Location_Id")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.Another_Hospital)
                .HasColumnName("Another_Hospital")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.Admitting_consultant_name_Id)
                .HasColumnName("Admitting_Consultant_Name_Id")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.IsCardiff)
               .HasColumnName("IsCardiff")
               .HasColumnType("bit")
               .IsRequired(); 
            builder.Property(x => x.IsSpecialist)
               .HasColumnName("IsSpecialist")
               .HasColumnType("bit")
               .IsRequired();
            builder.Property(x => x.Speciality_Id)
               .HasColumnName("Speciality_Id")
               .HasColumnType("INT")
               .IsRequired();
            builder.Property(x => x.Hospital_id)
               .HasColumnName("Hospital_Id")
               .HasColumnType("INT")
               .IsRequired();
            builder.Property(x => x.Provisional_diagnosis)
               .HasColumnName("Provisional_Diagnosis")
               .HasColumnType("NVARCHAR(100)")
               .IsRequired();
            builder.Property(x => x.Priority_Level_Id)
               .HasColumnName("Priority_Level_Id")
               .HasColumnType("INT")
               .IsRequired();
            builder.Property(x => x.Ward_Location_ID)
               .HasColumnName("Ward_Location_ID")
               .HasColumnType("INT")
               .IsRequired();
            builder.Property(x => x.Hospital_Ward_Location)
               .HasColumnName("Hospital_Ward_Location")
               .HasColumnType("NVARCHAR(100)")
               .IsRequired(false);
            builder.Property(x => x.ProvisionalDiagnosisSecondary)
               .HasColumnName("ProvisionalDiagnosisSecondary")
               .HasColumnType("NVARCHAR(100)").IsRequired(false);
        }

    }

}