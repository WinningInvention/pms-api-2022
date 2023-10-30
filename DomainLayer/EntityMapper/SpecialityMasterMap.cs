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
    public class SpecialityMasterMap : IEntityTypeConfiguration<SpecialityMaster>
    {
        public void Configure(EntityTypeBuilder<SpecialityMaster> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_SpecialityMasterid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("Speciality_id")
                .HasColumnType("INT");
            builder.Property(x => x.Speciality)
                .HasColumnName("Speciality")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
        }
    }
}
