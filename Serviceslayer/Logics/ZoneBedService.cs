using Serviceslayer.Interfaces;
using DomainLayer.Models;
using DomainLayer.DTO;
using RepositoryLayer.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace Serviceslayer.Logics
{
    public class ZoneBedService : IZoneBedService
    {
        private readonly IDatabaseCallService _datasbecall;
        private IRepositoryModified<PatientBed> _PatientBedrepository;
        private IRepositoryModified<Bed> _Bedrepository;
        private IRepositoryModified<Zone> _Zonerepository;
        private IRepository<Patient> _Patientrepository;
        private IRepository<Aicu_Patient_Form_Details> _ICUFormrepository;
        private IRepository<OutlierQueue_In> _outlierQueueInRepository;
        private IRepository<PriorityLevelMaster> _PriorityLevelMasterrepository;
        private readonly IMapper _mapper;
        private IRepositoryModified<PatientBedTracking> _PatientBedTrackingrepository;
        private IRepository<SpecialityMaster> _SpecialityMaster;
        public ZoneBedService(IDatabaseCallService datasbecall, 
            IRepositoryModified<PatientBed> PatientBedrepository, IRepositoryModified<Bed> Bedrepository,
            IRepositoryModified<Zone> Zonerepository, IRepository<Patient> Patientrepository, IMapper mapper, IRepository<Aicu_Patient_Form_Details> ICUFormrepository,
            IRepository<PriorityLevelMaster> priorityLevelMasterrepository, IRepositoryModified<PatientBedTracking> patientBedTrackingrepository, 
            IRepository<OutlierQueue_In> outlierQueueInRepository, IRepository<SpecialityMaster> specialityMaster)
        {
            _datasbecall = datasbecall;
            _PatientBedrepository = PatientBedrepository;
            _Zonerepository = Zonerepository;
            _Patientrepository = Patientrepository;
            _Bedrepository = Bedrepository;
            _mapper = mapper;
            _ICUFormrepository = ICUFormrepository;
            _PriorityLevelMasterrepository = priorityLevelMasterrepository;
            _PatientBedTrackingrepository = patientBedTrackingrepository;
            _outlierQueueInRepository = outlierQueueInRepository;
            _SpecialityMaster = specialityMaster;
        }
        public bool InsertZoneBed(Zone zone)
        {
            return _datasbecall.ExecuteCmdNonQuery("usp_CreateZoneBed", "@Zone_id", zone.ZoneId, "@ZoneName", zone.ZoneName, "@HospitalId", zone.HospitalId, "@TotalBeds", zone.TotalBeds, "@ZoneTypeId", zone.ZoneTypeId);
        }

        public IEnumerable<PatientBedDto> GetAllPatientBed(int ZoneId)
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            var exceptionList = new List<string> { "pacu", "recovery" };
            var GetAllocatedBed = (from b in _Bedrepository.GetAll()
                                  join z in _Zonerepository.GetAll(x => x.ZoneId == (ZoneId == 0 ? x.ZoneId : ZoneId)) on b.ZoneId equals z.ZoneId
                                  join p in _PatientBedrepository.GetAll(x => (x.IsDischarged == false) && !exceptionList.Contains(x.CurrentLocation)) on b.BedId equals p.BedId
                                   into BedpatientGroup
                                  from bp in BedpatientGroup.DefaultIfEmpty()
                                  select new PatientBedDto
                                  {
                                      BedId = b.BedId,
                                      PatientBedId = bp == null ? 0 : bp.PatientBedId,
                                      BedNumber = b.BedNumber,
                                      ZoneId = b.ZoneId,
                                      ZoneName = z.ZoneName,
                                      PatientId = bp == null ? 0 : bp.PatientId,
                                      AllocationDatetime = bp == null ? DateTime.Now : bp.AllocationDatetime,
                                      DischargeDatetime = bp == null ? null : bp.DischargeDatetime,
                                      PredictedDatetime = bp == null ? null : bp.PredictedDatetime,
                                      NurseId = bp == null ? 0 : bp.NurseId,
                                      IsDischarged = bp == null ? false : bp.IsDischarged,
                                      ClinicalRequirements = bp == null ? "" : bp.ClinicalRequirements ==null?"":bp.ClinicalRequirements,
                                      IsReadytoDischarge = bp == null ? false : bp.IsReadyDischarge,
                                      DischargeOutcome = bp==null? "": bp.DischargeOutcome,
                                      CurrentLocation = bp == null ? "" : bp.CurrentLocation,
                                      HandOverComment = bp == null ? "" : bp.Comment
                                  }).ToList();

            var priorityLevelAll = _PriorityLevelMasterrepository.GetAll();
            var specialityAll = _SpecialityMaster.GetAll();
            var GetAllocatedBedPatient = from x in GetAllocatedBed
                                         join pa in _Patientrepository.GetAll() on x.PatientId equals pa.Id
                                         into BedpatientGroup
                                         from bp in BedpatientGroup.DefaultIfEmpty()
                                         select new PatientBedDto
                                         {
                                             BedId = x.BedId,
                                             PatientBedId = x.PatientBedId,
                                             BedNumber = x.BedNumber,
                                             ZoneId = x.ZoneId,
                                             ZoneName = x.ZoneName,
                                             PatientId = x.PatientId == 0 ? null : x.PatientId,
                                             PatientName = bp == null ? "" : bp.Name,
                                             Provisionaldiagnosis = bp == null ? "" : bp.Provisional_diagnosis,
                                             PriorityLevelID = bp == null ? 0 : bp.Priority_Level_Id,
                                             PriorityLevelStatus = bp == null ? "" : (priorityLevelAll.Where(pl => pl.Id == bp.Priority_Level_Id).Select(pl => pl.Priority_Level).FirstOrDefault()),
                                             IsCardiff = bp == null ? null : bp.IsCardiff,
                                             IsSpecialist = bp == null ? null : bp.IsSpecialist,
                                             IsReadytoDischarge = x.IsReadytoDischarge,
                                             AllocationDatetime = x.AllocationDatetime,
                                             DischargeDatetime = x.DischargeDatetime,
                                             PredictedDatetime = x.PredictedDatetime,
                                             PredictedDatetimeString = x.PredictedDatetime ==null?"": TimeZoneInfo.ConvertTimeFromUtc((DateTime)x.PredictedDatetime,
                                                                INDIAN_ZONE).ToString("dd/MM/yyyy h:mm tt"),
                                             NurseId = x.NurseId,
                                             IsDischarged = x.IsDischarged,
                                             ClinicalRequirements = x.ClinicalRequirements,
                                             TotalICUDays = x.PatientId == 0 ? null : (DateTime.Now - _ICUFormrepository.GetAll().
                                                                        Where(icu => icu.Patient_Id == x.PatientId).Select(icu => icu.CreatedDate).FirstOrDefault()).Days,
                                             HospitalNumber = bp == null ? "" : bp.Hospital_Number,
                                             HealthBoard = bp == null ? "" : bp.health_board,
                                             SpecialityID = bp == null ? 0 : bp.Speciality_Id,
                                             SpecialityName = bp == null ? "" : specialityAll.Where(pl => pl.Id == bp.Speciality_Id).Select(pl => pl.Speciality).FirstOrDefault()
                                             , Age = bp ==null ?0:bp.Age,
                                             PatientHospitalNumber = bp == null?"":bp.Hospital_Number,
                                             DischargeOutcome = x.DischargeOutcome,
                                             CurrentLocation = x.CurrentLocation,
                                             HandOverComment = x.HandOverComment == null ? "" : x.HandOverComment

                                         };

            return GetAllocatedBedPatient;

        }
        public void InsertPatientBed(List<AllocatePatientBedDto> allocatePatientBedDto)
        {
            List<PatientBed> allocatePatientBed = _mapper.Map<List<PatientBed>>(allocatePatientBedDto);
            foreach (var item in allocatePatientBed)
            {
                item.AllocationDatetime = DateTime.Now;
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                item.IsActive = true;
            }          
            _PatientBedrepository.InsertBulk(allocatePatientBed);

            foreach (var item in allocatePatientBedDto)
            {
                var outlierQueue = _outlierQueueInRepository.Get(x=>x.Patient_Id == item.PatientId);
                if (outlierQueue !=null)
                    _outlierQueueInRepository.Delete(outlierQueue);
            }
        }
        public IEnumerable<AllZoneForBedDto> GetAllZone()
        {
            var Allzone = _Zonerepository.GetAll();
            List<AllZoneForBedDto> Allzonedto = _mapper.Map<List<AllZoneForBedDto>>(Allzone);
            return Allzonedto;

        }
        public IEnumerable<BedForZoneDto> GetAvailableBedByZone(int Zoneid)
        {
            var exceptionList = new List<string> { "pacu", "recovery" };
            List<int> PatientBed = _PatientBedrepository.GetAll(x => (x.IsDischarged == false) && !exceptionList.Contains(x.CurrentLocation)).Select(x => x.BedId).ToList();

            var emptyBedList = (from b in _Bedrepository.GetAll(x => x.ZoneId == Zoneid).Where(x => !PatientBed.Contains(x.BedId))
                                select new BedForZoneDto
                                {
                                    BedId = b.BedId,
                                    BedNumber = b.BedNumber
                                }).ToList();
                                      
            return emptyBedList;
        }
        public bool UpdateZoneBed(ZoneUpdateDto zone)
        {
            var GetAllocatedBedPatient = from b in _Bedrepository.GetAll().Where(x => x.ZoneId == zone.ZoneId && x.IsActive == true)
                                         join p in _PatientBedrepository.GetAll().Where(x => x.IsDischarged == false) on b.BedId equals p.BedId
                                         into BedpatientGroup
                                         from bp in BedpatientGroup.DefaultIfEmpty()
                                         select new PatientBedDto
                                         {
                                             BedId = b.BedId,
                                             BedNumber = b.BedNumber,
                                             ZoneId = b.ZoneId,
                                             PatientId = bp == null ? 0 : bp.PatientId,

                                         };

            var totalbedsinzone = _Bedrepository.GetAll().Where(x => x.ZoneId == zone.ZoneId && x.IsActive == true);

            if (zone.TotalBeds > totalbedsinzone.Count())
            {

                return _datasbecall.ExecuteCmdNonQuery("usp_CreateZoneBed", "@Zone_id", zone.ZoneId, "@ZoneName", zone.ZoneName, "@HospitalId", 0, "@TotalBeds", zone.TotalBeds, "@ZoneTypeId", 0);

            }
            if (zone.TotalBeds < totalbedsinzone.Count())
            {

                var CheckAvailablePatientInZone = GetAllocatedBedPatient.Where(x => x.PatientId != 0 && x.PatientId != null);

                if (CheckAvailablePatientInZone.Count() > 0)
                {
                    var bednumber = new List<int>();
                    for (int i = GetAllocatedBedPatient.Count(); i > zone.TotalBeds; i--)
                    {

                        var GetBedNumber = CheckAvailablePatientInZone.Where(x => x.BedNumber == i).FirstOrDefault();
                        if (GetBedNumber != null)
                        {
                            bednumber.Add(GetBedNumber.BedNumber);
                        }
                    }
                    if (bednumber.Count() > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return _datasbecall.ExecuteCmdNonQuery("usp_CreateZoneBed", "@Zone_id", zone.ZoneId, "@ZoneName", zone.ZoneName, "@HospitalId", 0, "@TotalBeds", zone.TotalBeds, "@ZoneTypeId", 0);
                    }
                }
                else
                {
                    return _datasbecall.ExecuteCmdNonQuery("usp_CreateZoneBed", "@Zone_id", zone.ZoneId, "@ZoneName", zone.ZoneName, "@HospitalId", 0, "@TotalBeds", zone.TotalBeds, "@ZoneTypeId", 0);
                }
            }
            return _datasbecall.ExecuteCmdNonQuery("usp_CreateZoneBed", "@Zone_id", zone.ZoneId, "@ZoneName", zone.ZoneName, "@HospitalId", 0, "@TotalBeds", zone.TotalBeds, "@ZoneTypeId", 0);
        }
        public bool DeleteZoneBed(int zoneid)
        {
            var GetAllocatedBedPatient = from b in _Bedrepository.GetAll().Where(x => x.ZoneId == zoneid && x.IsActive == true)
                                         join p in _PatientBedrepository.GetAll().Where(x => x.IsDischarged == false) on b.BedId equals p.BedId
                                         into BedpatientGroup
                                         from bp in BedpatientGroup.DefaultIfEmpty()
                                         select new PatientBedDto
                                         {
                                             BedId = b.BedId,
                                             BedNumber = b.BedNumber,
                                             ZoneId = b.ZoneId,
                                             PatientId = bp == null ? 0 : bp.PatientId,

                                         };
            var CheckAvailablePatientInZone = GetAllocatedBedPatient.Where(x => x.PatientId != 0 && x.PatientId != null);
            if (CheckAvailablePatientInZone.Count() > 0)
            {
                return false;
            }
            else
            {
                Zone zone = new Zone();
                zone = _Zonerepository.Get(x => x.ZoneId == zoneid);
                zone.IsActive = false;
                zone.ModifiedDate = DateTime.Now;
                _Zonerepository.Update(zone);
                foreach (var item in _Bedrepository.GetAll().Where(x => x.ZoneId == zoneid && x.IsActive == true).ToList())
                {
                    item.IsActive = false;
                    item.ModifiedDate = DateTime.Now;
                    _Bedrepository.Update(item);
                }

                return true;
            }
        }
        public bool MovePatient(MovePatientDto movePatient)
        {

            var getOldPatientBed = _PatientBedrepository.Get(x => x.PatientBedId == movePatient.PatientBedId);
            PatientBedTracking patientBedTracking = new PatientBedTracking();
            patientBedTracking.BedId = getOldPatientBed.BedId;
            patientBedTracking.PatientBedId = movePatient.PatientBedId;
            _PatientBedTrackingrepository.Insert(patientBedTracking);

            getOldPatientBed.BedId = movePatient.BedId;
            _PatientBedrepository.Update(getOldPatientBed);

            return true;
        }

        public IEnumerable<ZoneBedBirdViewDto> GetZoneBedBirdView()
        {
            var Allzone = _Zonerepository.GetAll();
            List<ZoneBedBirdViewDto> Allzonedto = _mapper.Map<List<ZoneBedBirdViewDto>>(Allzone);

            foreach (var item in Allzonedto)
            {
                item.PatientBedList = GetAllPatientBed(item.ZoneId).ToList();
            }

            return Allzonedto;
        }

        public void InsertOrUpdatePatientBedComment(AddCommentPatientBedDto addCommentPatientBedDto)
        {
            var getpatientBed = _PatientBedrepository.Get(x => x.PatientBedId == addCommentPatientBedDto.PatientBedId);
            if (getpatientBed == null)
            {
                PatientBed patientBed = new PatientBed();
                patientBed.Comment = addCommentPatientBedDto.HandOverComment;
                _PatientBedrepository.Insert(patientBed);
            }
            else
            {
                getpatientBed.Comment = addCommentPatientBedDto.HandOverComment;
                _PatientBedrepository.Update(getpatientBed);
            }   
        }

        public AddCommentPatientBedDto GetCommentByPatientBedId(int PatientBedId)
        {
            var getpatientBed = _PatientBedrepository.Get(x => x.PatientBedId == PatientBedId);
            AddCommentPatientBedDto addCommentPatientBedDto = new AddCommentPatientBedDto();
            if (getpatientBed != null)
            {
                addCommentPatientBedDto.PatientBedId = getpatientBed.PatientBedId;
                addCommentPatientBedDto.HandOverComment = getpatientBed.Comment;
                return addCommentPatientBedDto;
            }
            return addCommentPatientBedDto ;
        }

    }
}
