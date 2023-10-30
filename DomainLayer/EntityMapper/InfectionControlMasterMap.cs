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
    public class InfectionControlMasterMap: IEntityTypeConfiguration<InfectionControlMaster>
    {
        public void Configure(EntityTypeBuilder<InfectionControlMaster> builder)
        {
            builder.HasKey(x => x.InfectionControlId).HasName("pk_InfectionControlId");
            builder.Property(x => x.InfectionControlId).ValueGeneratedOnAdd()
                .HasColumnName("InfectionControlId")
                .HasColumnType("INT");
            builder.Property(x => x.InfectionControlValue)
              .HasColumnName("InfectionControlValue")
              .HasColumnType("NVARCHAR(250)")
              .IsRequired();

        }
    }
}
