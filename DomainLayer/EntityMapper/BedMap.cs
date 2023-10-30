using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.EntityMapper
{
    public class BedMap : IEntityTypeConfiguration<Bed>
    {
        public void Configure(EntityTypeBuilder<Bed> builder)
        {
            builder.HasKey(x => x.BedId).HasName("pk_BedId");
            builder.Property(x => x.BedId).ValueGeneratedOnAdd()
                .HasColumnName("BedId")
                .HasColumnType("INT");
            builder.Property(x => x.BedNumber)
               .HasColumnName("BedNumber")
               .HasColumnType("INT")
               .IsRequired();
            builder.Property(x => x.ZoneId)
               .HasColumnName("ZoneId")
               .HasColumnType("INT")
               .IsRequired();
        }
    }
}
