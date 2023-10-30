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
    public class HospitalLocationMasterMap : IEntityTypeConfiguration<HospitalLocationMaster>
    {
        public void Configure(EntityTypeBuilder<HospitalLocationMaster> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_hospitalLocationMasterid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("Location_Id")
                .HasColumnType("INT");
            builder.Property(x => x.Hospital_Location)
                .HasColumnName("Hospital_Location")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
        }

    }
}
