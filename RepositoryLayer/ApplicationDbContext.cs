using System;
using Microsoft.EntityFrameworkCore;
using DomainLayer.EntityMapper;
using DomainLayer.Models;
using System.Data;

namespace RepositoryLayer
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HospitalMap());
           // base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PriorityLevelMasterMap());
           // base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HospitalLocationMasterMap());
           // base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SpecialityMasterMap());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ReferalMap());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new Aicu_Patient_Form_DetailsMap());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PatientMap());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new referal_status_MasterMap());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OutlierQueue_InMap());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new hospital_Ward_Location_MasterMAP());
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RepatriationMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ZoneTypeMasterMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ZoneMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BedMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PatientBedMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PatientBedTrackingMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ReferalCommentMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NurseAvailabilityMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new  NurseAvailabilityTrackingMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OutlierOutQueueMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OutlierQueueInCommentMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DischargeCommentMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OutlierOutQueueCommentMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClinicalRequirementMasterMap());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new InfectionControlMasterMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

