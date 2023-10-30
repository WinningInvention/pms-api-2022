using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.EntityMapper
{
    public class ZoneMap : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder.HasKey(x => x.ZoneId).HasName("pk_ZoneId");
            builder.Property(x => x.ZoneId).ValueGeneratedOnAdd()
                .HasColumnName("ZoneId")
                .HasColumnType("INT");
            builder.Property(x => x.ZoneName)
              .HasColumnName("ZoneName")
              .HasColumnType("NVARCHAR(100)")
              .IsRequired();
            builder.Property(x => x.TotalBeds)
               .HasColumnName("TotalBeds")
               .HasColumnType("INT")
               .IsRequired();
            builder.Property(x => x.ZoneTypeId)
               .HasColumnName("ZoneTypeId")
               .HasColumnType("INT")
               .IsRequired();
            builder.Property(x => x.HospitalId)
               .HasColumnName("HospitalId")
               .HasColumnType("INT")
               .IsRequired();

        }
    }
}
