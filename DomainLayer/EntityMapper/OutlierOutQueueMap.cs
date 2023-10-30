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
    public class OutlierOutQueueMap : IEntityTypeConfiguration<OutlierOutQueue>
    {
        public void Configure(EntityTypeBuilder<OutlierOutQueue> builder)
        {
            builder.HasKey(x => x.OutlierOutQueueId).HasName("pk_OutlierOutQueueId");
            builder.Property(x => x.OutlierOutQueueId).ValueGeneratedOnAdd()
                .HasColumnName("OutlierOutQueueId")
                .HasColumnType("INT");
            builder.Property(x => x.PatientBedId)
              .HasColumnName("PatientBedId")
              .HasColumnType("INT");
            builder.Property(x => x.PatientId)
             .HasColumnName("PatientId")
             .HasColumnType("INT");
            builder.Property(x => x.StartTime)
                .HasColumnName("StartTime")
                .HasColumnType("datetime");
            builder.Property(x => x.EndTime)
               .HasColumnName("EndTime")
               .HasColumnType("datetime");
        }
    }
}
