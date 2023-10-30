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
    public class ReferalCommentMap : IEntityTypeConfiguration<ReferalComment>
    {
        public void Configure(EntityTypeBuilder<ReferalComment> builder)
        {
            builder.HasKey(x => x.ReferalCommentId).HasName("pk_ReferalCommentId");
            builder.Property(x => x.ReferalCommentId).ValueGeneratedOnAdd()
                .HasColumnName("ReferalCommentId")
                .HasColumnType("INT");
            builder.Property(x => x.ReferalId)
              .HasColumnName("ReferalId")
              .HasColumnType("NVARCHAR(100)")
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
