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
    public class OutlierQueue_InMap : IEntityTypeConfiguration<OutlierQueue_In>
    {
        public void Configure(EntityTypeBuilder<OutlierQueue_In> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_outlierQueue_Inid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("OutlierQueue_In_Id")
                .HasColumnType("INT");
            builder.Property(x => x.Patient_Id)
                .HasColumnName("Patient_Id")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.Priority_Level_id)
                .HasColumnName("Priority_Level_id")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.Start_Datetime)
                .HasColumnName("Start_Datetime")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
