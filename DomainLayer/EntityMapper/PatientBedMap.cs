using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Models
{
    public class PatientBedMap : IEntityTypeConfiguration<PatientBed>
    {
        public void Configure(EntityTypeBuilder<PatientBed> builder)
        {
            builder.HasKey(x => x.PatientBedId).HasName("pk_PatientBedId");
            builder.Property(x => x.PatientBedId).ValueGeneratedOnAdd()
                .HasColumnName("PatientBedId")
                .HasColumnType("INT");
            builder.Property(x => x.PatientId)
              .HasColumnName("PatientId")
              .HasColumnType("INT")
              .IsRequired();
            builder.Property(x => x.BedId)
             .HasColumnName("BedId")
             .HasColumnType("INT")
             .IsRequired();
            builder.Property(x => x.AllocationDatetime)
            .HasColumnName("AllocationDatetime")
            .HasColumnType("datetime")
            .IsRequired();
            builder.Property(x => x.NurseId)
               .HasColumnName("NurseId")
               .HasColumnType("INT")
               .IsRequired();
            builder.Property(x => x.DischargeDatetime)
           .HasColumnName("DischargeDatetime")
           .HasColumnType("datetime");
            builder.Property(x => x.PredictedDatetime)
          .HasColumnName("PredictedDatetime")
          .HasColumnType("datetime");
            builder.Property(x => x.IsDischarged)
          .HasColumnName("IsDischarged")
          .HasColumnType("bit")
          .IsRequired();
            builder.Property(x => x.DischargeTypeId)
             .HasColumnName("DischargeTypeId")
             .HasColumnType("INT")
             .IsRequired();
            builder.Property(x => x.ClinicalRequirements)
            .HasColumnName("ClinicalRequirements")
            .HasColumnType("NVARCHAR(500)")
            .IsRequired(false);
            builder.Property(x => x.IsReadyDischarge)
          .HasColumnName("IsReadyDischarge")
          .HasColumnType("bit");
            builder.Property(x => x.DischargeOutcome)
            .HasColumnName("DischargeOutcome")
            .HasColumnType("NVARCHAR(500)")
            .IsRequired(false);
            builder.Property(x => x.CurrentLocation)
            .HasColumnName("CurrentLocation")
            .HasColumnType("NVARCHAR(500)")
            .IsRequired(false);
            builder.Property(x => x.Destination)
            .HasColumnName("Destination")
            .HasColumnType("NVARCHAR(500)")
            .IsRequired(false);
            builder.Property(x => x.ConsultantName)
            .HasColumnName("ConsultantName")
            .HasColumnType("NVARCHAR(500)")
            .IsRequired(false);

        }
    }
}
