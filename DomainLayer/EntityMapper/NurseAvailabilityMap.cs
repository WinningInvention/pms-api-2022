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
    public class NurseAvailabilityMap : IEntityTypeConfiguration<NurseAvailability>
    {
        public void Configure(EntityTypeBuilder<NurseAvailability> builder)
        {
            builder.HasKey(x => x.NurseAvailablityId).HasName("pk_NurseAvailabilityId");
            builder.Property(x => x.NurseAvailablityId).ValueGeneratedOnAdd()
                .HasColumnName("NurseAvailabilityId")
                .HasColumnType("INT");
            builder.Property(x => x.AvailabilityDate)
                .HasColumnName("AvailabilityDate")
                .HasColumnType("DateTime")
                .IsRequired();
            builder.Property(x => x.FirstShift)
                .HasColumnName("FirstShift")
                .HasColumnType("INT");
            builder.Property(x => x.SecondShift)
                .HasColumnName("SecondShift")
                .HasColumnType("INT");
                
        }

       
    }
}
