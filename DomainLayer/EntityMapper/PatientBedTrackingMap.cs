using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DomainLayer.EntityMapper
{
    public class PatientBedTrackingMap : IEntityTypeConfiguration<PatientBedTracking>
    {
        public void Configure(EntityTypeBuilder<PatientBedTracking> builder)
        {
            builder.HasKey(x => x.PatientBedTrackingId).HasName("pk_ PatientBedTrackingId");
            builder.Property(x => x.PatientBedTrackingId).ValueGeneratedOnAdd()
                .HasColumnName("PatientBedTrackingId")
                .HasColumnType("INT");
            builder.Property(x => x.PatientBedId)
              .HasColumnName("PatientBedId")
              .HasColumnType("INT")
              .IsRequired();
            builder.Property(x => x.BedId)
               .HasColumnName("BedId")
               .HasColumnType("INT")
               .IsRequired();
                  }
    }
}
