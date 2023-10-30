using AutoMapper;
using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using Serviceslayer.Interfaces;


namespace Serviceslayer.Logics
{
    public class ReferalmasterService : IReferalmasterService
    {
        
        private IRepository<Referal> _ReferalRepository;
        private IRepository<Patient> _PatientRepository;
        private IRepository<referal_status_Master> _referalStatusMasterRepository;
        private IRepository<Aicu_Patient_Form_Details> _AicuPatientFormDetailsRepository;
        private IRepository<PriorityLevelMaster> _PriorityLevelMasterRepository;
        private IRepositoryModified<ReferalComment> _ReferalCommentRepository;
        private IRepository<OutlierQueue_In> _OutlierQueueInRepository;
        private IRepository<Repatriation> _repatriationRepository;
        private readonly IMapper _mapper;

        public ReferalmasterService(IRepository<Referal> repository, IRepository<Patient> Patientrepository, IRepository<referal_status_Master> referalStatusMasterRepository,
            IRepository<Aicu_Patient_Form_Details> aicuPatientFormDetailsRepository, IRepository<PriorityLevelMaster> PriorityLevelMasterRepository,
            IRepositoryModified<ReferalComment> ReferalCommentRepository, 
            IRepository<OutlierQueue_In> outlierQueueInRepository, IMapper mapper, IRepository<Repatriation> repatriationRepository)
        {
            _ReferalRepository = repository;
            _PatientRepository = Patientrepository;
            _referalStatusMasterRepository = referalStatusMasterRepository;
            _AicuPatientFormDetailsRepository = aicuPatientFormDetailsRepository;
            _PriorityLevelMasterRepository = PriorityLevelMasterRepository;
            _ReferalCommentRepository = ReferalCommentRepository;
            _mapper = mapper;
            _OutlierQueueInRepository = outlierQueueInRepository;
            _repatriationRepository = repatriationRepository;
        }

        public Referal GetReferal(int id)
        {
            return _ReferalRepository.Get(id);
        }

        public IEnumerable<ReferalListDto> GetListReferal()
        {
            var resultAdmittedNonAdmitted = from r in _ReferalRepository.GetAll().Where(x => x.Start_Datetime >= DateTime.Now.ToUniversalTime().AddDays(-1))
                                            join p in _PatientRepository.GetAll() on r.Patient_Id equals p.Id
                                            join rsm in _referalStatusMasterRepository.GetAll().Where(x => x.Status == "Admitted" || x.Status == "Not admitted") on r.Referal_Status_Id equals rsm.Id
                                            join aicu in _AicuPatientFormDetailsRepository.GetAll() on r.Patient_Id equals aicu.Patient_Id
                                            join plm in _PriorityLevelMasterRepository.GetAll() on p.Priority_Level_Id equals plm.Id
                                            orderby r.Start_Datetime descending
                                            select new ReferalListDto
                                            {
                                                ReferalID = r.Id,
                                                ReferalStatusId = r.Referal_Status_Id,
                                                ReferalStatus = rsm.Status,
                                                Comment = r.Comment,
                                                StartDatetime = r.Start_Datetime,
                                                PatientId = p.Id,
                                                PatientName = p.Name,
                                                HospitalNumber = p.Hospital_Number,
                                                Age = p.Age,
                                                ProvisionalDiagnosis = p.Provisional_diagnosis,
                                                PreviousMedicalSurgicalHistory = aicu.Previous_Medical_Surgical_History,
                                                LevelOfCare = plm.Priority_Level,
                                                OrderBy = rsm.OrderBy
                                            };

            var resultOthers = from r in _ReferalRepository.GetAll()
                               join p in _PatientRepository.GetAll() on r.Patient_Id equals p.Id
                               join rsm in _referalStatusMasterRepository.GetAll().Where(x => x.Status != "Admitted" && x.Status != "Not admitted") on r.Referal_Status_Id equals rsm.Id
                               join aicu in _AicuPatientFormDetailsRepository.GetAll() on r.Patient_Id equals aicu.Patient_Id
                               join plm in _PriorityLevelMasterRepository.GetAll() on p.Priority_Level_Id equals plm.Id
                               orderby r.Start_Datetime descending
                               select new ReferalListDto
                               {
                                   ReferalID = r.Id,
                                   ReferalStatusId = r.Referal_Status_Id,
                                   ReferalStatus = rsm.Status,
                                   Comment = r.Comment,
                                   StartDatetime = r.Start_Datetime,
                                   PatientId = p.Id,
                                   PatientName = p.Name,
                                   HospitalNumber = p.Hospital_Number,
                                   Age = p.Age,
                                   ProvisionalDiagnosis = p.Provisional_diagnosis,
                                   PreviousMedicalSurgicalHistory = aicu.Previous_Medical_Surgical_History,
                                   LevelOfCare = plm.Priority_Level,
                                   OrderBy = rsm.OrderBy
                               };

            var result = resultAdmittedNonAdmitted.Concat(resultOthers).OrderBy(x => x.OrderBy);

            return result;

        }

        public IEnumerable<RepatrationListDto> GetListRepatration()
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            var result = from r in _repatriationRepository.GetAll()
                               join p in _PatientRepository.GetAll() on r.Patient_Id equals p.Id
                               join aicu in _AicuPatientFormDetailsRepository.GetAll() on r.Patient_Id equals aicu.Patient_Id
                               orderby r.CreatedDate descending
                               select new RepatrationListDto
                               {
                                   RepatriationID = r.Id,
                                   CreatedDate = TimeZoneInfo.ConvertTimeFromUtc((DateTime)r.CreatedDate,
                                                            INDIAN_ZONE).ToString("dd/MM/yyyy h:mm tt") ,
                                   PatientId = p.Id,
                                   PatientName = p.Name,
                                   HospitalNumber = p.Hospital_Number,
                                   Age = p.Age,
                                   ProvisionalDiagnosis = p.Provisional_diagnosis,
                                   PreviousMedicalSurgicalHistory = aicu.Previous_Medical_Surgical_History,
                                   RepatType = r.RepatType,
                                   RepatHospitalName = r.RepatHospitalName
                               };


            return result.OrderByDescending(x =>x.CreatedDate);

        }

        public void InsertComment(CreateCommentDto comment)
        {
            ReferalComment referalComment = _mapper.Map<ReferalComment>(comment);
            referalComment.UserName = "default";
            _ReferalCommentRepository.Insert(referalComment);

            var referal = _ReferalRepository.Get(referalComment.ReferalId);
            referal.Referal_Status_Id = comment.ReferalStatusId;
            _ReferalRepository.Update(referal);

            var referalStatus = _referalStatusMasterRepository.Get(comment.ReferalStatusId);
            if (referalStatus.Status == "Admitted")
            {
                var data = _OutlierQueueInRepository.Get( x =>x.Patient_Id == referal.Patient_Id);
                if (data == null)
                {
                    var patient = _PatientRepository.Get(referal.Patient_Id);

                    OutlierQueue_In outlierQueue_In = new OutlierQueue_In();
                    outlierQueue_In.Patient_Id = referal.Patient_Id;
                    outlierQueue_In.Start_Datetime = DateTime.Now;
                    outlierQueue_In.Priority_Level_id = patient.Priority_Level_Id;
                    _OutlierQueueInRepository.Insert(outlierQueue_In);
                }

            }
        }

        public IEnumerable<CommentListDto> GetReferalCommentById(int ReferalId)
        {
            var allReferalsComments = _ReferalCommentRepository.GetAll();
            var referalCommentById = allReferalsComments.Where(x => x.ReferalId == ReferalId);
            List<CommentListDto> referalComments = _mapper.Map<List<CommentListDto>>(referalCommentById);
            return referalComments;
        }
    }
}
