using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using Serviceslayer.Interfaces;
using AutoMapper;

namespace Serviceslayer.Logics
{
    public class OutlierOutService : IOutlierOutService
    {
        private IRepositoryModified<PatientBed> _patientBedrepository;
        private readonly IMapper _mapper;
        private IRepositoryModified<OutlierOutQueue> _outlierOutQueueRepository;
        private IRepository<Patient> _Patientrepository;
        private IRepository<PriorityLevelMaster> _PriorityLevelMasterRepository;
        private IRepositoryModified<OutlierOutQueueComment> _OutlierOutQueueCommentRepository;
        private IRepositoryModified<Bed> _bedRepository;
        private IRepositoryModified<Zone> _zoneRepository;
        public OutlierOutService(IRepositoryModified<PatientBed> patientBedrepository,
            IMapper mapper,
            IRepositoryModified<OutlierOutQueue> outlierOutQueueRepository,
            IRepository<Patient> patientrepository,
            IRepository<PriorityLevelMaster> priorityLevelMasterRepository,
            IRepositoryModified<OutlierOutQueueComment> outlierOutQueueCommentRepository, IRepositoryModified<Bed> bedRepository, IRepositoryModified<Zone> zoneRepository)
        {

            _patientBedrepository = patientBedrepository;
            _mapper = mapper;
            _outlierOutQueueRepository = outlierOutQueueRepository;
            _Patientrepository = patientrepository;
            _PriorityLevelMasterRepository = priorityLevelMasterRepository;
            _OutlierOutQueueCommentRepository = outlierOutQueueCommentRepository;
            _bedRepository = bedRepository;
            _zoneRepository = zoneRepository;
        }
        public IEnumerable<OutlierOutListDto> GetListOutlierQueueIn()
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            var exceptionList = new List<string> { "pacu", "recovery" };
            var result = from oq in _outlierOutQueueRepository.GetAll()
                         join p in _Patientrepository.GetAll() on oq.PatientId equals p.Id
                         join pb in _patientBedrepository.GetAll(x => exceptionList.Contains(x.CurrentLocation)) on oq.PatientBedId equals pb.PatientBedId
                         join b in _bedRepository.GetAll() on pb.BedId equals b.BedId
                         join z in _zoneRepository.GetAll() on b.ZoneId equals z.ZoneId
                         join plm in _PriorityLevelMasterRepository.GetAll() on p.Priority_Level_Id equals plm.Id
                         select new OutlierOutListDto
                         {

                             PatientId = p.Id,
                             PatientBedId = oq.PatientBedId,
                             PatientName = p.Name,
                             OutlierOutQueueId = oq.OutlierOutQueueId,
                             StartDatetime = TimeZoneInfo.ConvertTimeFromUtc((DateTime)oq.StartTime,
                                                                INDIAN_ZONE).ToString("dd/MM/yyyy h:mm tt"),
                             NumberOfDays = (DateTime.Now - oq.StartTime).Days,
                             PriorityLevel = plm.Priority_Level,
                             PriorityLevelid = plm.Id,
                             CurrentLocation = pb.CurrentLocation,
                             Destination = pb.Destination,
                             ConsultantName = pb.ConsultantName,
                             PredicatedDateTime = pb.PredictedDatetime == null ? "" :
                                                                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)pb.PredictedDatetime,
                                                                    INDIAN_ZONE).ToString("dd/MM/yyyy h:mm tt"),
                             Zone = z.ZoneName,
                             BedNumber = b.BedNumber
                         };

            return result.OrderByDescending(x => x.StartDatetime);
        }

        public void InsertOutlierOutQueueComment(OutlierOutQueueCommentDto outlierOutQueueCommentDto)
        {
            OutlierOutQueueComment outlierOutQueueComment = _mapper.Map<OutlierOutQueueComment>(outlierOutQueueCommentDto);
            _OutlierOutQueueCommentRepository.Insert(outlierOutQueueComment);
        }

        public IEnumerable<OutlierOutQueueCommentDto> GetOutlierOutQueueCommentById(int outlierOutQueueId)
        {
            var alloutlierOutQueueComment = _OutlierOutQueueCommentRepository.GetAll();
            var outlierOutQueueCommentById = alloutlierOutQueueComment.Where(x => x.OutlierOutQueueId == outlierOutQueueId);
            List<OutlierOutQueueCommentDto> outlierOutQueueComments = _mapper.Map<List<OutlierOutQueueCommentDto>>(outlierOutQueueCommentById);
            return outlierOutQueueComments;
        }
    }
}
