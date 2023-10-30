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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_Userid");
            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("User_Id")
                .HasColumnType("INT");
            builder.Property(x => x.UserName)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired(false);
            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.EmailId)
                .HasColumnName("EmailId")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.UserTypeId)
                .HasColumnName("UserTypeId")
                .HasColumnType("INT")
                .IsRequired();
            builder.Property(x => x.UserdDetails)
                .HasColumnName("UserdDetails")
                .HasColumnType("NVARCHAR(100)")
                .IsRequired();
            builder.Property(x => x.HospitlId)
                .HasColumnName("HospitlId")
                .HasColumnType("INT")
                .IsRequired();
        }
    }
}
