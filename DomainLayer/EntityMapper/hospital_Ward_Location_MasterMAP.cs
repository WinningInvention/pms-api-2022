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
    public class hospital_Ward_Location_MasterMAP : IEntityTypeConfiguration<hospital_Ward_Location_Master>
    {
        public void Configure(EntityTypeBuilder<hospital_Ward_Location_Master> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_hospitalWardLocationMasterid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("Hospital_Ward_Location_Master_Id")
                .HasColumnType("INT");
            builder.Property(x => x.Wards_Name)
                .HasColumnName("Wards_Name")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.Hospital_Locatio_Id)
                .HasColumnName("Hospital_Locatio_Id")
                .HasColumnType("INT")
                .IsRequired();
        }
    }
}
