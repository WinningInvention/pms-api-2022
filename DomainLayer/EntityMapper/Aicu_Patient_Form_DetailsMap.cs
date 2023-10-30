using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.EntityMapper
{
    public class Aicu_Patient_Form_DetailsMap : IEntityTypeConfiguration<Aicu_Patient_Form_Details>
    {
        public void Configure(EntityTypeBuilder<Aicu_Patient_Form_Details> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_aicuPatientFormDetailsMasterid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("Aicu_Patient_Form_Details_Id")
                .HasColumnType("INT");
            builder.Property(x => x.Patient_Id)
                .HasColumnName("Patient_Id")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.Consultant_Id)
                .HasColumnName("Consultant_Id")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.Referring_Staff_Name)
                .HasColumnName("Referring_Staff_Name")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.Clinical_Requirement_Id)
                .HasColumnName("Clinical_Requirement_Id")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.Previous_Medical_Surgical_History)
                .HasColumnName("Previous_Medical_Surgical_History")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.InfectionControlID)
                .HasColumnName("InfectionControlID")
                .HasColumnType("INT")
                .IsRequired(false);
            builder.Property(x => x.OtherIntectionControl)
                .HasColumnName("OtherIntectionControl")
                .HasColumnType("NVARCHAR(500)").IsRequired(false);
            builder.Property(x => x.Referal_Date_Time)
                .HasColumnName("Referal_Date_Time")
                .HasColumnType("Datetime")
                .IsRequired();
        }
    }
}
