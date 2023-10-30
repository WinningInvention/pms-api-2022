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
    public class DischargeCommentMap : IEntityTypeConfiguration<DischargeComment>
    {
        public void Configure(EntityTypeBuilder<DischargeComment> builder)
        {
            builder.HasKey(x => x.DischargeCommentId).HasName("pk_DischargeCommentId");
            builder.Property(x => x.DischargeCommentId).ValueGeneratedOnAdd()
                .HasColumnName("DischargeCommentId")
                .HasColumnType("INT");
            builder.Property(x => x.DischargeId)
              .HasColumnName("DischargeId")
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
