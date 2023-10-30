using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.EntityMapper
{
    public class RepatriationMap : IEntityTypeConfiguration<Repatriation>
    {
        public void Configure(EntityTypeBuilder<Repatriation> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_repatriationMapid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("RepatriationMap_Id")
                .HasColumnType("INT");
            builder.Property(x => x.Patient_Id)
                .HasColumnName("Patient_Id")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.RepatType)
                .HasColumnName("RepatType")
                .HasColumnType("NVARCHAR(50)").IsRequired(false);
            builder.Property(x => x.RepatHospitalName)
                .HasColumnName("RepatHospitalName")
                .HasColumnType("NVARCHAR(500)").IsRequired(false);
            builder.Property(x => x.RepatConsultantName)
                .HasColumnName("RepatConsultantName")
                .HasColumnType("NVARCHAR(500)").IsRequired(false);
        }
    }
}
