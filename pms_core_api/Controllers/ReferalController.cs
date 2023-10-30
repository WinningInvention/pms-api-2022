using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using pms_core_api.Models;
using Serviceslayer.Interfaces;

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("PMSPolicy")]
    public class ReferalController : Controller
    {
        private readonly IReferalmasterService _referalmasterService;
        private readonly IPatientService _patientService;
        private readonly IReferalStatusMasterService _referalStatusMasterService;
        public ReferalController(IReferalmasterService referalmasterService, IPatientService patientService,
                IReferalStatusMasterService referalStatusMasterService)
        {
            _referalmasterService = referalmasterService;
            _patientService = patientService;
            _referalStatusMasterService = referalStatusMasterService;
        }
        [HttpGet(nameof(GetReferalDetails))]
        public IActionResult GetReferalDetails(int id)
        {
            var referalDetails = _referalmasterService.GetReferal(id);
            if (referalDetails is not null)
            {
                ReferalModel referalModel = new ReferalModel()
                {
                    ReferalId = referalDetails.Id,
                    Comment = referalDetails.Comment,
                    PatientDetails = _patientService.GetPatient(referalDetails.Patient_Id),
                    ReferalStatus = _referalStatusMasterService.GetReferalStatus(referalDetails.Referal_Status_Id),
                    Start_Datetime = referalDetails.Start_Datetime,
                    //CreatedDate = referalDetails.CreatedDate,
                    //ModifiedDate = referalDetails.ModifiedDate,
                    //IsActive = referalDetails.IsActive
                };
                return Ok(referalModel);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetListReferal))]
        public IActionResult GetListReferal()
        {
            var result = _referalmasterService.GetListReferal();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetListRepatration))]
        public IActionResult GetListRepatration()
        {
            var result = _referalmasterService.GetListRepatration();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetCommentsByReferalId))]
        public IActionResult GetCommentsByReferalId(int ReferalId)
        {
            var result = _referalmasterService.GetReferalCommentById(ReferalId);

            if (result is not null)
            {
                return Ok(result);
            }
            return Ok("No records found");
        }

        [HttpPost(nameof(InsertComment))]
        public IActionResult InsertComment([FromBody] CreateCommentDto createCommentDTO)
        {
            _referalmasterService.InsertComment(createCommentDTO);
            return Ok("Data inserted");
        }
    }
}
