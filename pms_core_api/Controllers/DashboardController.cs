using DomainLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Serviceslayer.Interfaces;
using System.Net;

namespace pms_core_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly INurseTrackingService _nurseTrackingService;
        private readonly IReferalmasterService _referalmasterService;
        private readonly IDischargeService _dischargeService;

        public DashboardController(IDashboardService dashboardService, INurseTrackingService nurseTrackingService, 
            IReferalmasterService referalmasterService, IDischargeService dischargeService)
        {
            _dashboardService = dashboardService;
            _nurseTrackingService = nurseTrackingService;
            _referalmasterService = referalmasterService;
            _dischargeService = dischargeService;
        }

        [HttpGet(nameof(GetGraphValue))]
        public ResponseFormatDto GetGraphValue()
        {
            var bedList = _dashboardService.GetOccupyVaccantBed().ToList();
            var nurse = _nurseTrackingService.GetTotalRequiredNurseByDate().ToList();
            var patinetCount = _dashboardService.GetL2L3PatientCount().ToList();
            var resultSpecialist = _dashboardService.GetSpecialistDto();
            var resultCardiffCount = _dashboardService.GetCardiffCount();

            DashboardDto dashboardDto = new()
            {
                OccupyVacantBedDtoList = bedList,
                L2L3PateintCountDtoList = patinetCount,
                lstTotalNurseRequiredListDto = nurse,
                OccupiedArray = bedList.Select(x => x.OccupiedBed).ToArray(),
                VaccantArray = bedList.Select(x => x.VaccantBed).ToArray(),
                ZoneName = bedList.Select(x => x.ZoneName).ToArray(),
                NurseAvailable = nurse.Select(x => x.NurseAvailableFirstShift).ToArray(),
                NurseRequired = nurse.Select(x => x.NurseRequiredFirstShift).ToArray(),
                L2PatientCount = patinetCount.Select(x => x.L2PatientCount).ToArray(),
                L3PatientCount = patinetCount.Select(x => x.L3PatientCount).ToArray(),
                ReferalCount = _referalmasterService.GetListReferal().Count(),
                TotalL2Patient = patinetCount.Where(x => x.Date.Date == DateTime.Now.Date).
                                    Select(x => x.L2PatientCount).FirstOrDefault(),
                TotalL3Patient = patinetCount.Where(x => x.Date.Date == DateTime.Now.Date).
                                    Select(x => x.L3PatientCount).FirstOrDefault(),
                NurseCount = nurse.Where(x => x.Date.Date == DateTime.Now.Date).
                        Select(x => x.NurseRequiredFirstShift).FirstOrDefault(),
                ZoneCount = bedList.Select(x => x.ZoneName).Count(),
                DischargeCount = _dischargeService.GetPatientDischargeList().Count(),
                SpecialistCount = resultSpecialist.SpecialistCount,
                NonSpecialistCount = resultSpecialist.NonSpecialistCount,
                CardiffCount = resultCardiffCount.CardiffCount,
                NonCardfiffCount = resultCardiffCount.NonCardfiffCount
            };
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();

            if (dashboardDto is not null)
            {
                responseFormatDto.statusCode = (int)HttpStatusCode.Accepted;
                responseFormatDto.data = dashboardDto;    
                return responseFormatDto;
            }
            return responseFormatDto;
        }

        [HttpGet(nameof(GetCardiffCount))]
        public ResponseFormatDto GetCardiffCount()
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _dashboardService.GetCardiffCount();

            if (result is not null)
            {
                responseFormatDto.statusCode = (int)HttpStatusCode.Accepted;
                responseFormatDto.data = result;
                return responseFormatDto;
            }
            return responseFormatDto;
        }

        [HttpGet(nameof(GetSpecialistDto))]
        public ResponseFormatDto GetSpecialistDto()
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _dashboardService.GetSpecialistDto();

            if (result is not null)
            {
                responseFormatDto.statusCode = (int)HttpStatusCode.Accepted;
                responseFormatDto.data = result;
                return responseFormatDto;
            }
            return responseFormatDto;
        }
    }
}
