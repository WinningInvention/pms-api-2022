using System;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.EntityMapper
{
    public class HospitalMap : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_hospitalid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("Hospital_Id")
                .HasColumnType("INT");
            builder.Property(x => x.HospitalName)
                .HasColumnName("Hospital_Name")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.CreatedDate)
               .HasColumnName("Created_Date")
               .HasColumnType("datetime")
               .IsRequired();
            builder.Property(x => x.ModifiedDate)
                .HasColumnName("Modified_Date")
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(x => x.IsActive)
                .HasColumnName("Is_Active")
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}

