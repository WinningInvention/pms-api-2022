using AutoMapper;
using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repository;
using Serviceslayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Logics
{
    public class NurseTrackingService : INurseTrackingService
    {

        private IRepositoryModified<NurseAvailability> _NurseAvailabilityRepository;
        private IRepository<Patient> _PatientRepository;
        private IRepository<PriorityLevelMaster> _PriorityLevelMasterRepository;
        private IRepositoryModified<PatientBed> _patientBedRepository;
        private IRepositoryModified<NurseAvailabilityTracking> _nurseAvailabilityTrackingRepository;
        private readonly IMapper _mapper;
        public NurseTrackingService(IRepositoryModified<NurseAvailability> NurseAvailabilityRepository, IRepository<Patient> PatientRepository,
            IRepository<PriorityLevelMaster> PriorityLevelMasterRepository, IMapper mapper, IRepositoryModified<PatientBed> patientBedRepository,
            IRepositoryModified<NurseAvailabilityTracking> nurseAvailabilityTrackingRepository)
        {
            _NurseAvailabilityRepository = NurseAvailabilityRepository;
            _PatientRepository = PatientRepository;
            _PriorityLevelMasterRepository= PriorityLevelMasterRepository;
            _mapper = mapper;
            _patientBedRepository = patientBedRepository;
            _nurseAvailabilityTrackingRepository = nurseAvailabilityTrackingRepository;
        }
        public void InsertAvailableNurse(List<NurseAvailabilityDto> nurseAvailabilityDto)
        {
            var lstNurseAvailability = _mapper.Map<List<NurseAvailability>>(nurseAvailabilityDto);
            foreach (var nurseAvailability in lstNurseAvailability)
            {
                nurseAvailability.CreatedDate = DateTime.Now;
                nurseAvailability.ModifiedDate = DateTime.Now;
                nurseAvailability.IsActive = true;
            }
            _NurseAvailabilityRepository.InsertBulk(lstNurseAvailability);
        }
        public IEnumerable<NurseAvailability> GetAllNurse()
        {
            var AllData = _NurseAvailabilityRepository.GetAll();
            return AllData;
        }
        public IEnumerable<UpdateNurseAvailablityDto> GetById(int id)
        {
            var AllData = _NurseAvailabilityRepository.GetAll();
            var getDataById = AllData.Where(x => x.NurseAvailablityId == id);
            List<UpdateNurseAvailablityDto> nurseAvailabilities = _mapper.Map<List<UpdateNurseAvailablityDto>>(getDataById);
            return nurseAvailabilities;
        }
        public void UpdateNurseAvailability(UpdateNurseAvailablityDto availableNurse)
        {

            var oldNurseAvailability = _NurseAvailabilityRepository.Get(x => x.NurseAvailablityId == availableNurse.NurseAvailablityId);
            NurseAvailabilityTracking nurseAvailabilityTracking = new NurseAvailabilityTracking();
            nurseAvailabilityTracking.NurseAvailablityId = oldNurseAvailability.NurseAvailablityId;
            nurseAvailabilityTracking.FirstShift = oldNurseAvailability.FirstShift;
            nurseAvailabilityTracking.SecondShift = oldNurseAvailability.SecondShift;
            nurseAvailabilityTracking.AvailabilityDate = oldNurseAvailability.AvailabilityDate;
            _nurseAvailabilityTrackingRepository.Insert(nurseAvailabilityTracking);

            oldNurseAvailability.FirstShift = availableNurse.FirstShift;
            oldNurseAvailability.SecondShift = availableNurse.SecondShift;
            _NurseAvailabilityRepository.Update(oldNurseAvailability);

        }
        public IEnumerable<TotalNurseRequiredListDto> GetTotalRequiredNurseByDate()
        {

            string priorityLevelL2 = "L2";
            string prioityLevelL3 = "L3";

            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
            DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);

            var priorityLevelL2Id = _PriorityLevelMasterRepository.Get(x => x.Priority_Level == priorityLevelL2);
            var priorityLevelL3Id = _PriorityLevelMasterRepository.Get(x => x.Priority_Level == prioityLevelL3);

            var nurseRequiredListByDate = new List<TotalNurseRequiredListDto>();

            var allPatientBed = _patientBedRepository.GetAll().ToList();
            var allPatientData = _PatientRepository.GetAll().ToList();
            var todayDate = DateTime.Now;

            for (int i = 0; i < 7; i++)
            {
                var tempDate = currentWeekStartDate.AddDays(i);
                var tempTotalNurseRequiredListDto = new TotalNurseRequiredListDto();
                tempTotalNurseRequiredListDto.Date = tempDate;
                if (tempDate > todayDate)
                    tempDate = todayDate;

                var nurseRequiredL2 = (from r in allPatientBed.Where(x => x.AllocationDatetime <= tempDate
                                       && ((x.DischargeDatetime == null ? todayDate : x.DischargeDatetime) >= tempDate))
                                       join p in allPatientData.Where(x => x.Priority_Level_Id == priorityLevelL2Id.Id) on r.PatientId equals p.Id
                                       select new { r.PatientId }
                                                 ).ToList().Count();
                if (nurseRequiredL2 % 2 == 0)
                    nurseRequiredL2 = nurseRequiredL2 / 2;
                else
                    nurseRequiredL2 = (nurseRequiredL2 +1) / 2;

                var nurseRequiredL3 = ((from r in allPatientBed.Where(x => x.AllocationDatetime <= tempDate
                                       && ((x.DischargeDatetime == null ? todayDate : x.DischargeDatetime) >= tempDate))
                                        join p in allPatientData.Where(x => x.Priority_Level_Id == priorityLevelL3Id.Id) on r.PatientId equals p.Id
                                        select new { r.PatientId }
                                               ).ToList().Count());

                tempTotalNurseRequiredListDto.NurseRequiredFirstShift = nurseRequiredL2 + nurseRequiredL3;
                tempTotalNurseRequiredListDto.NurseRequiredSecondShift = nurseRequiredL2 + nurseRequiredL3;

                nurseRequiredListByDate.Add(tempTotalNurseRequiredListDto);
            }

            var nurseAvailabilities = _NurseAvailabilityRepository.GetAll().ToList();

            var finalResult = (from r in nurseRequiredListByDate
                      join p in nurseAvailabilities on r.Date.Date equals p.AvailabilityDate.Date
                      select new TotalNurseRequiredListDto
                      {
                          NurseRequiredFirstShift = r.NurseRequiredFirstShift,
                          NurseRequiredSecondShift = r.NurseRequiredSecondShift,
                          NurseAvailableFirstShift = p.FirstShift,
                          NurseAvailableSecondShift = p.SecondShift,
                          Date = r.Date.Date
                      }).ToList();

            return finalResult;
        }
    }
}
