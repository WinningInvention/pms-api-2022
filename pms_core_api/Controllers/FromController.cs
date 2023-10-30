using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using pms_core_api.Models;
using RepositoryLayer;
using Serviceslayer.Interfaces;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PMSPolicy")]
    public class FromController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IHospitalLocationMasterService _hospitalLocationService;
        private readonly IHospitalWardLocationMasterService _hospitalWardLocationMasterService;
        private readonly IDatabaseCallService _datasbecall;
        private readonly IHospitalLocationMasterService _locationService;
        private readonly IPriorityLevelMasterService _priorityLevelService;
        private readonly ISpecialityMasterService _specialityService;
        private readonly IReferalStatusMasterService _referalStatusService;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;
        private readonly IPatientService _patientService;
        private readonly IInfectionControlMasterService _infectionService;
        public FromController(IHospitalLocationMasterService hospitalLocationService,
            IPriorityLevelMasterService priorityLevelService, 
            ISpecialityMasterService specialityService, IReferalStatusMasterService referalStatusService, IUserService userService,
            IDatabaseCallService datasbecall, IHospitalWardLocationMasterService hospitalWardLocationMasterService
            , IPatientService patientService, IInfectionControlMasterService infectionService)
        {
            _hospitalLocationService = hospitalLocationService;
            _priorityLevelService = priorityLevelService;
            _specialityService = specialityService;
            _referalStatusService = referalStatusService;
            _userService = userService;
            _datasbecall = datasbecall;
            _hospitalWardLocationMasterService = hospitalWardLocationMasterService;
            _patientService = patientService;
            _infectionService = infectionService;
        }
        [HttpGet(nameof(GetAllHospitalLocation))]
        public IActionResult GetAllHospitalLocation()
        {
            var result = _hospitalLocationService.GetAllHospitaLocation();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpGet(nameof(GetAllPriorityLevel))]
        public IActionResult GetAllPriorityLevel()
        {
            var result = _priorityLevelService.GetAllPriorityLevel();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpGet(nameof(GetAllSpecialityMaster))]
        public IActionResult GetAllSpecialityMaster()
        {
            var result = _specialityService.GetAllSpecialityMaster();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            return BadRequest("No records found");

        }
        [HttpGet(nameof(GetAllDroupDownData))]
        public IActionResult GetAllDroupDownData()
        {
            GetFromDropDownDataModel fromModel = new GetFromDropDownDataModel
            {
                locationMaster = _hospitalLocationService.GetAllHospitaLocation().ToList(),
                specialityMaster = _specialityService.GetAllSpecialityMaster().ToList(),
                priorityLevelMaster = _priorityLevelService.GetAllPriorityLevel().ToList(),
                ICU_care_Status = _referalStatusService.GetAllReferalStatus().ToList(),
                Admitting_consultant_name = _userService.GetAllUser().Where(x => x.Id == 1).ToList(),
                lstInfectionControlMaster = _infectionService.GetInfectionControlList()
            };
            if (fromModel is not null)
            {
                return Ok(fromModel);
            }
            return BadRequest("No records found");
        }
        [HttpGet(nameof(GetWardLocationMasterByLocationId))]
        public IActionResult GetWardLocationMasterByLocationId(int hospitalLocationId)
        {
            var Hospital_ward_location_Master_by_LocationId = _hospitalWardLocationMasterService.GetAllHospitalWardLocation().Where(i => i.Hospital_Locatio_Id == hospitalLocationId).ToList();
            if (Hospital_ward_location_Master_by_LocationId is not null)
            {
                return Ok(Hospital_ward_location_Master_by_LocationId);
            }
            return BadRequest("No records found");
        }
        [HttpPost(nameof(SubmitFromData))]
        public IActionResult SubmitFromData([FromBody] FromModel fromData)
        {

            var jsonFromModule = JsonSerializer.Serialize(fromData);
            bool submitflag = _datasbecall.InsertDatawithStoredProcedure("InsertFromDataNew", "@fromModuelData", jsonFromModule);

            if (submitflag == true) return Ok("Inser success");
            else return BadRequest("Insert not success");

        }

        [HttpPost(nameof(UpdatePatientDetails))]
        public ResponseFormatDto UpdatePatientDetails([FromBody] UpdatePatientDetailsDto updatePatientDetailsDto)
        {
            _patientService.UpdatePatientDetails(updatePatientDetailsDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }
    }
}
