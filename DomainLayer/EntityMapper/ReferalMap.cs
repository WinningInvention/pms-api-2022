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
    public class ReferalMap : IEntityTypeConfiguration<Referal>
    {
        public void Configure(EntityTypeBuilder<Referal> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_Referalid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("Referal_Id")
                .HasColumnType("INT");
            builder.Property(x => x.Patient_Id)
                .HasColumnName("Patient_Id")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.Referal_Status_Id)
                .HasColumnName("Referal_Status_Id")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.Comment)
                .HasColumnName("Comment")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired(false); 
        }
    }
}
