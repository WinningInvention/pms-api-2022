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
    public class PriorityLevelMasterMap : IEntityTypeConfiguration<PriorityLevelMaster>
    {
        public void Configure(EntityTypeBuilder<PriorityLevelMaster> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_PriorityLevelMasterid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("LevelId")
                .HasColumnType("INT");
            builder.Property(x => x.Priority_Level)
                .HasColumnName("Priority_Level")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
        }
    }
}
