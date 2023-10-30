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
    public class referal_status_MasterMap : IEntityTypeConfiguration<referal_status_Master>
    {
        public void Configure(EntityTypeBuilder<referal_status_Master> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_referal_StatusMasterid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("Referal_status_Master_id")
                .HasColumnType("INT");
            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.OrderBy)
                .HasColumnName("OrderBy")
                .HasColumnType("INT")
                .IsRequired();
        }
    }
}
