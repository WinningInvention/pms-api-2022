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
    public class NurseAvailabilityTrackingMap: IEntityTypeConfiguration<NurseAvailabilityTracking>
    {
        public void Configure(EntityTypeBuilder<NurseAvailabilityTracking> builder)
         {
             builder.HasKey(x => x.NurseAvailabilityTrackingId).HasName("pk_NurseAvailabilityTrackingId");
             builder.Property(x => x.NurseAvailabilityTrackingId).ValueGeneratedOnAdd()
                 .HasColumnName("NurseAvailabilityTrackingId")
                 .HasColumnType("INT");
            builder.Property(x => x.NurseAvailablityId)
               .HasColumnName("NurseAvailablityId")
               .HasColumnType("INT");
            builder.Property(x => x.AvailabilityDate)
               .HasColumnName("AvailabilityDate")
               .HasColumnType("DateTime");    
             builder.Property(x => x.FirstShift)
                .HasColumnName("FirstShift")
                .HasColumnType("INT");
             builder.Property(x => x.SecondShift)
                .HasColumnName("SecondShift")
                .HasColumnType("INT");

         }
    }
}

