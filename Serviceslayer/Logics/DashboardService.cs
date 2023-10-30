using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using Serviceslayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Logics
{
    public class DashboardService:IDashboardService
    {
        private IRepositoryModified<PatientBed> _PatientBedrepository;
        private IRepositoryModified<Bed> _Bedrepository;
        private IRepository<PriorityLevelMaster> _PriorityLevelMasterRepository;
        private IRepository<Patient> _PatientRepository;
        private IRepositoryModified<Zone> _Zonerepository;
        public DashboardService(IRepositoryModified<PatientBed> PatientBedrepository, IRepositoryModified<Bed> Bedrepository, IRepository<PriorityLevelMaster> PriorityLevelMasterRepository, IRepository<Patient> PatientRepository,
            IRepositoryModified<Zone> Zonerepository)
        {
            _PatientBedrepository = PatientBedrepository;
            _Bedrepository = Bedrepository;
            _PriorityLevelMasterRepository= PriorityLevelMasterRepository;
            _PatientRepository = PatientRepository;
            _Zonerepository = Zonerepository;
        }

        public IEnumerable<OccupyVacantBedDto> GetOccupyVaccantBed()
        {
            List<int> PatientBed = _PatientBedrepository.GetAll(x => x.IsDischarged == false).Select(x => x.BedId).ToList();

            var occupiedBedList = (from b in _Bedrepository.GetAll().Where(x => PatientBed.Contains(x.BedId) && x.IsActive==true)
                                   select new {
                                       BedId = b.BedId,
                                       ZoneId = b.ZoneId,
                                       BedNumber = b.BedNumber
                                   }).ToList();

            var emptyBedList = (from b in _Bedrepository.GetAll().Where(x => !PatientBed.Contains(x.BedId) && x.IsActive==true)
                                select new 
                                {
                                    BedId = b.BedId,
                                    ZoneId=b.ZoneId,
                                    BedNumber = b.BedNumber
                                }).ToList();

            var vaccantBed = emptyBedList.GroupBy(x=>x.ZoneId).Select(m=>
                                 new OccupyVacantBedDto
                                 {   ZoneId = m.Key,
                                    VaccantBed =m.Count()
                                }).ToList();

            var occupiedBed= occupiedBedList.GroupBy(x => x.ZoneId).Select(m =>
                                    new OccupyVacantBedDto
                                    {   ZoneId = m.Key,
                                        OccupiedBed =m.Count()
                                    }).ToList();

            var vaccancyoccupylist = from v in vaccantBed
                            join o in occupiedBed on v.ZoneId equals o.ZoneId into vaccantoccupy
                            from oc in vaccantoccupy.DefaultIfEmpty()
                            select new OccupyVacantBedDto
                            {
                                ZoneId=v.ZoneId,
                                VaccantBed=v.VaccantBed,
                                OccupiedBed= oc == null ? 0 : oc.OccupiedBed
                            };

            var finallist = from vc in vaccancyoccupylist
                            join z in _Zonerepository.GetAll() on vc.ZoneId equals z.ZoneId
                             select new OccupyVacantBedDto
                              {
                                  ZoneId=vc.ZoneId,
                                  ZoneName=z.ZoneName,
                                  VaccantBed=vc.VaccantBed,
                                  OccupiedBed=vc.OccupiedBed
                              };              
               return finallist;
        }
        public IEnumerable<L2L3PateintCountDto> GetL2L3PatientCount()
        {
            string priorityLevelL2 = "L2";
            string prioityLevelL3 = "L3";

            DayOfWeek currentDay = DateTime.Now.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
            DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);

            var priorityLevelL2Id = _PriorityLevelMasterRepository.Get(x => x.Priority_Level == priorityLevelL2);
            var priorityLevelL3Id = _PriorityLevelMasterRepository.Get(x => x.Priority_Level == prioityLevelL3);

            var L1L2ByDate = new List<L2L3PateintCountDto>();
            var allPatientBed = _PatientBedrepository.GetAll().ToList();
            var allPatientData = _PatientRepository.GetAll().ToList();
            var todayDate = DateTime.Now;

            for (int i = 0; i < 7; i++)
            {
                var tempDate = currentWeekStartDate.AddDays(i);
                var tempL1L2Dto = new L2L3PateintCountDto();
                tempL1L2Dto.Date = tempDate;

                if (tempDate > todayDate)
                    tempDate = todayDate;

                var L2 = (from r in allPatientBed.Where(x => x.AllocationDatetime <= tempDate
                                       && ((x.DischargeDatetime == null ? todayDate : x.DischargeDatetime) >= tempDate))
                          join p in allPatientData.Where(x => x.Priority_Level_Id == priorityLevelL2Id.Id) 
                          on r.PatientId equals p.Id
                          select new { r.PatientId }
                                                 ).ToList().Count();

                var L3 = ((from r in allPatientBed.Where(x => x.AllocationDatetime <= tempDate
                                       && ((x.DischargeDatetime == null ? todayDate : x.DischargeDatetime) >= tempDate))
                           join p in allPatientData.Where(x => x.Priority_Level_Id == priorityLevelL3Id.Id) on r.PatientId equals p.Id
                           select new { r.PatientId }
                                               ).ToList().Count());

                tempL1L2Dto.L2PatientCount=L2;
                tempL1L2Dto.L3PatientCount=L3;
                L1L2ByDate.Add(tempL1L2Dto);
            }
            return L1L2ByDate;
        }
        public GetCardiffDto GetCardiffCount()
        {
            var patients = _PatientRepository.GetAll();
            GetCardiffDto dto = new GetCardiffDto();
            dto.CardiffCount = patients.Where(x => x.IsCardiff == true).Count();
            dto.NonCardfiffCount = patients.Where(x => x.IsCardiff == false).Count();

            return dto;
        }
        public GetSpecialistDto GetSpecialistDto()
        {
            var patients = _PatientRepository.GetAll();
            GetSpecialistDto dto = new GetSpecialistDto();
            dto.SpecialistCount = patients.Where(x => x.IsSpecialist == true).Count();
            dto.NonSpecialistCount = patients.Where(x => x.IsSpecialist == false).Count();

            return dto;
        }
    }
}
