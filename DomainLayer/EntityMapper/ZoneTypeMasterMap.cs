
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.EntityMapper
{
    public class ZoneTypeMasterMap : IEntityTypeConfiguration<ZoneTypeMaster>
    {
        public void Configure(EntityTypeBuilder<ZoneTypeMaster> builder)
        {
            builder.HasKey(x => x.ZoneTypeId).HasName("pk_ZoneTypeMasterZoneTypeId");
            builder.Property(x => x.ZoneTypeId).ValueGeneratedOnAdd()
                .HasColumnName("ZoneTypeId")
                .HasColumnType("INT");
            builder.Property(x => x.ZoneType)
               .HasColumnName("ZoneType")
               .HasColumnType("NVARCHAR(100)")
               .IsRequired();
        }
    }
}
