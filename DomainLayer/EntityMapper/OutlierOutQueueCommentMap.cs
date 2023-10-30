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
    public class OutlierOutQueueCommentMap : IEntityTypeConfiguration<OutlierOutQueueComment>
    {
        public void Configure(EntityTypeBuilder<OutlierOutQueueComment> builder)
        {
            builder.HasKey(x => x.OutlierOutQueueCommentId).HasName("pk_OutlierOutQueueCommentId");
            builder.Property(x => x.OutlierOutQueueCommentId).ValueGeneratedOnAdd()
                .HasColumnName("OutlierOutQueueCommentId")
                .HasColumnType("INT");
            builder.Property(x => x.OutlierOutQueueId)
              .HasColumnName("OutlierOutQueueId")
              .HasColumnType("INT")
              .IsRequired();
            builder.Property(x => x.Comment)
               .HasColumnName("Comment")
               .HasColumnType("NVARCHAR(250)")
               .IsRequired();
            builder.Property(x => x.UserName)
               .HasColumnName("UserName")
               .HasColumnType("NVARCHAR(250)")
               .IsRequired();


        }
    }
}
