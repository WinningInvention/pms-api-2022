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
   public class ClinicalRequirementMasterMap : IEntityTypeConfiguration<ClinicalRequirementMaster>
    {
        public void Configure(EntityTypeBuilder<ClinicalRequirementMaster> builder)
        {
            builder.HasKey(x => x.ClinicalRequirementId).HasName("pk_ClinicalRequirementId");
            builder.Property(x => x.ClinicalRequirementId).ValueGeneratedOnAdd()
                .HasColumnName("ClinicalRequirementId")
                .HasColumnType("INT");
            builder.Property(x => x.ClinicalRequirement)
              .HasColumnName("ClinicalRequirement")
              .HasColumnType("NVARCHAR(250)")
              .IsRequired();
          
       }
    }
}
