using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using Serviceslayer.Interfaces;
using AutoMapper;
using DomainLayer;

namespace Serviceslayer.Logics
{
    public class OutlierQueueInService : IOutlierQueueInService
    {
        private IRepository<OutlierQueue_In> _OutlierQueueInRepository;
        private IRepository<Patient> _PatientRepository;
        private IRepository<PriorityLevelMaster> _PriorityLevelMasterRepository;
        private IRepositoryModified<OutlierQueueInComment> _OutlierQueueInCommentRepository;
        private readonly IMapper _mapper;

        public OutlierQueueInService(IRepository<OutlierQueue_In> repository, IRepository<Patient> Patientrepository , 
            IRepository<PriorityLevelMaster> priorityLevelMasterRepository, IRepositoryModified<OutlierQueueInComment> outlierQueueInCommentRepository, IMapper mapper) {
            _OutlierQueueInRepository = repository;
            _PatientRepository = Patientrepository;
            _PriorityLevelMasterRepository = priorityLevelMasterRepository;
            _OutlierQueueInCommentRepository = outlierQueueInCommentRepository;
            _mapper = mapper;
        }
        public IEnumerable<OutlierQueue_In> GetAllOutlierQueueIn()
        {
            return _OutlierQueueInRepository.GetAll();
        }

        public OutlierQueue_In GetOutlierQueueIn(int id)
        {
            return _OutlierQueueInRepository.Get(id);
        }

        public IEnumerable<OutlierQueueInDto> GetListOutlierQueueIn()
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            var OrganSupportReqList = CustomConstant.GetOrganSupportList();

            var result = from oq in _OutlierQueueInRepository.GetAll()
                         join p in _PatientRepository.GetAll() on oq.Patient_Id equals p.Id
                         join plm in _PriorityLevelMasterRepository.GetAll() on oq.Priority_Level_id equals plm.Id


                         select new OutlierQueueInDto
                         {

                             PatientId = p.Id,
                             PatientName = p.Name,
                             OutlierQueueInId = oq.Id,
                             IsActive = oq.IsActive,
                             StartDatetime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)oq.Start_Datetime,
                                                            INDIAN_ZONE).ToString("dd/MM/yyyy h:mm tt"),
                             PriorityLevel = plm.Priority_Level,
                             PriorityLevelid = plm.Id,
                             NumberOfDays = (DateTime.Now - oq.Start_Datetime).Days,
                             ProvisionalDiagnosis = p.Provisional_diagnosis,
                             OrganSupportRequired = String.Join("," , OrganSupportReqList.Where(x =>
                                    p.Organ_Support_requirements.Split(',').Select(int.Parse).ToList().
                                                            Contains(x.ID)).Select(x => x.OrganSupportName))
                           
                       };

            return result.OrderByDescending(x=>x.StartDatetime);

        }

        public void InsertOutlierQueueInComment(OutlierQueueInCommentDto outlierQueueInCommentDto)
        {
            OutlierQueueInComment outlierQueueInComment = _mapper.Map<OutlierQueueInComment>(outlierQueueInCommentDto);
            _OutlierQueueInCommentRepository.Insert(outlierQueueInComment);
        }

        public IEnumerable<OutlierQueueInCommentDto> GetOutlierQueueInCommentById(int OutlierQueueInId)
        {
            var outlierQueueInComment = _OutlierQueueInCommentRepository.GetAll(x => x.OutlierQueueInId == OutlierQueueInId);
            List<OutlierQueueInCommentDto> outlierQueueIns = _mapper.Map<List<OutlierQueueInCommentDto>>(outlierQueueInComment);
            return outlierQueueIns;
        }
    }
}
