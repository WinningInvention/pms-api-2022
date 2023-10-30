using AutoMapper;
using DomainLayer;
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
    public class DischargeService : IDischargeService
    {
        private IRepositoryModified<PatientBed> _patientBedrepository;
        private IRepository<Repatriation> _repatriationRepository;
        private readonly IMapper _mapper;
        private IRepositoryModified<OutlierOutQueue> _outlierOutQueueRepository;
        private IRepository<Patient> _Patientrepository;
        private IRepositoryModified<DischargeComment> _DischargeCommentRepository;
        private IRepository<PriorityLevelMaster> _PriorityLevelMasterRepository;

        public DischargeService(IRepositoryModified<PatientBed> patientBedrepository,
            IMapper mapper,
            IRepositoryModified<OutlierOutQueue> outlierOutQueueRepository,
            IRepository<Patient> patientrepository,
            IRepositoryModified<DischargeComment> dischargeCommentRepository,
            IRepository<PriorityLevelMaster> priorityLevelMasterRepository,
            IRepository<Repatriation> repatriationRepository)
        {
            _patientBedrepository = patientBedrepository;
            _mapper = mapper;
            _outlierOutQueueRepository = outlierOutQueueRepository;
            _Patientrepository = patientrepository;
            _DischargeCommentRepository = dischargeCommentRepository;
            _PriorityLevelMasterRepository = priorityLevelMasterRepository;
            _repatriationRepository = repatriationRepository;
        }

        public void PredictedDated(PredictedDischargeDTO predictedDischargeDTO)
        {
            var patientBed = _patientBedrepository.Get(x => x.PatientBedId == predictedDischargeDTO.PatientBedId);
            patientBed.PredictedDatetime = predictedDischargeDTO.PredictedDatetime;
            _patientBedrepository.Update(patientBed);
        }

        public void ReadyToDischarge(ReadyToDischargeDto readyToDischargeDto)
        {
            var patientBed = _patientBedrepository.Get(x => x.PatientBedId == readyToDischargeDto.PatientBedId);
            patientBed.IsReadyDischarge = true;
            patientBed.CurrentLocation = readyToDischargeDto.CurrentLocation;
            patientBed.DischargeOutcome = readyToDischargeDto.DischargeOutcome;
            patientBed.Destination = readyToDischargeDto.Destination;
            patientBed.ConsultantName = readyToDischargeDto.ConsultantName;
            _patientBedrepository.Update(patientBed);

            if (readyToDischargeDto.DischargeOutcome.ToLower() == "repatriation")
            {
                var repatExists = _repatriationRepository.Get(x => x.Patient_Id == patientBed.PatientId);

                if (repatExists == null)
                {
                    var repatOut = new Repatriation();
                    repatOut.Patient_Id = patientBed.PatientId;
                    repatOut.Is_Repatriation = true;
                    repatOut.RepatType = CustomConstant.RepatOut;
                    repatOut.RepatConsultantName = readyToDischargeDto.ConsultantName;
                    repatOut.RepatHospitalName = readyToDischargeDto.Destination;
                    _repatriationRepository.Insert(repatOut);
                }
            }

            var outlierQueueExist = _outlierOutQueueRepository.Get(x => x.PatientBedId == readyToDischargeDto.PatientBedId);
            if (outlierQueueExist == null)
            {
                OutlierOutQueue outlierOutQueue = new OutlierOutQueue();
                outlierOutQueue.PatientBedId = patientBed.PatientBedId;
                outlierOutQueue.PatientId = patientBed.PatientId;
                outlierOutQueue.StartTime = DateTime.Now;
                _outlierOutQueueRepository.Insert(outlierOutQueue);
            }
        }

        public void FinalDischarge(PatientDischargeDto patientDischargeDto)
        {

            var patientBed = _patientBedrepository.Get(x => x.PatientBedId == patientDischargeDto.PatientBedId);
            patientBed.DischargeDatetime = patientDischargeDto.DischargeDatetime;
            patientBed.IsDischarged = true;
            _patientBedrepository.Update(patientBed);

            var outlierQueue = _outlierOutQueueRepository.Get(x => x.PatientBedId == patientDischargeDto.PatientBedId);
            if (outlierQueue != null)
                _outlierOutQueueRepository.Delete(outlierQueue);
        }

        public List<DischargeListDto> GetPatientDischargeList()
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            var dischargeListDtos = (from x in _patientBedrepository.GetAll(x => x.IsDischarged == true)
                                     join pa in _Patientrepository.GetAll() on x.PatientId equals pa.Id
                                     select new DischargeListDto
                                     {
                                         PatientBedId = x.PatientBedId,
                                         PatientId = x.PatientId,
                                         PatientName = pa.Name,
                                         DischargeDateTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)x.DischargeDatetime,
                                                            INDIAN_ZONE).ToString("dd/MM/yyyy h:mm tt")

                                     }).ToList();
            return dischargeListDtos;
        }

        public List<PredictedDischargeListDto> PredictedDischargeList()
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            var priorityLevelAll = _PriorityLevelMasterRepository.GetAll();
            var dischargeListDtos = (from x in _patientBedrepository.GetAll(x => x.PredictedDatetime != null && x.IsDischarged == false && x.IsReadyDischarge == false)
                                     //.Where(t => t.PredictedDatetime <= DateTime.Now.ToUniversalTime().AddDays(+2) && t.PredictedDatetime >= DateTime.Now.ToUniversalTime())
                                     join pa in _Patientrepository.GetAll() on x.PatientId equals pa.Id
                                     join plm in _PriorityLevelMasterRepository.GetAll() on pa.Priority_Level_Id equals plm.Id
                                     select new PredictedDischargeListDto
                                     {
                                         PatientBedId = x.PatientBedId,
                                         PatientId = x.PatientId,
                                         PatientName = pa.Name,
                                         Diagnosis = pa.Provisional_diagnosis,
                                         LevelOfCare = plm.Priority_Level,
                                         StartDatetime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)x.AllocationDatetime,
                                                                INDIAN_ZONE).ToString("dd/MM/yyyy h:mm tt"),
                                         NumberOfDays = (DateTime.Now - x.AllocationDatetime).Days,
                                         PredictedDateTime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)x.PredictedDatetime,
                                                            INDIAN_ZONE).ToString("dd/MM/yyyy h:mm tt")

                                     }).ToList();


            return dischargeListDtos;
        }

        public void InsertDischargeComment(DischargeCommentDto dischargeCommentDto)
        {
            DischargeComment dischargeComment = _mapper.Map<DischargeComment>(dischargeCommentDto);
            _DischargeCommentRepository.Insert(dischargeComment);
        }

        public IEnumerable<DischargeCommentDto> GetDischargeCommentById(int dischargeId)
        {
            var alldischargeComment = _DischargeCommentRepository.GetAll();
            var dischargeCommentById = alldischargeComment.Where(x => x.DischargeId == dischargeId);
            List<DischargeCommentDto> dischargeComments = _mapper.Map<List<DischargeCommentDto>>(dischargeCommentById);
            return dischargeComments;
        }

        public List<ReadyDischargeListDto> ReadyDischargeList()
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            var priorityLevelAll = _PriorityLevelMasterRepository.GetAll();
            var readydischargeListDtos = (from x in _patientBedrepository.GetAll(x => x.IsReadyDischarge == true && x.IsDischarged == false)
                                          join pa in _Patientrepository.GetAll() on x.PatientId equals pa.Id
                                          select new ReadyDischargeListDto
                                          {
                                              PatientId = x.PatientId,
                                              PatientName = pa.Name,
                                              CurrentLocation = x.CurrentLocation,
                                              StartDatetime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)x.AllocationDatetime,
                                                                INDIAN_ZONE).ToString("dd/MM/yyyy h:mm tt"),
                                              NumberOfDays = (DateTime.Now - x.AllocationDatetime).Days,
                                              DischargeOutcome = x.DischargeOutcome,
                                              PredictedDateTime = x.PredictedDatetime == null?"" : TimeZoneInfo.ConvertTimeFromUtc((DateTime)x.PredictedDatetime,
                                                            INDIAN_ZONE).ToString("dd/MM/yyyy h:mm tt"),
                                              Destination = x.Destination,
                                              ConsultantName = x.ConsultantName,

                                          }).ToList();
            return readydischargeListDtos;
        }
    }
}
