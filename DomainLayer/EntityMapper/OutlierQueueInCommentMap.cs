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
    public class OutlierQueueInCommentMap: IEntityTypeConfiguration<OutlierQueueInComment>
    {
        public void Configure(EntityTypeBuilder<OutlierQueueInComment> builder)
        {
            builder.HasKey(x => x.OutlierQueueInCommentId).HasName("pk_OutlierQueueInCommentId");
            builder.Property(x => x.OutlierQueueInCommentId).ValueGeneratedOnAdd()
                .HasColumnName("OutlierQueueInCommentId")
                .HasColumnType("INT");
            builder.Property(x => x.OutlierQueueInId)
              .HasColumnName("OutlierQueueInId")
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
