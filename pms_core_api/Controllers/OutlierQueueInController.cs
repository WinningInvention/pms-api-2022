using DomainLayer.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using pms_core_api.Models;
using Serviceslayer.Interfaces;
using System.Net;

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PMSPolicy")]
    public class OutlierQueueInController : Controller
    {
        private readonly IOutlierQueueInService _oulierQueueIn;
        private readonly IPatientService _patientService;
        private readonly IPriorityLevelMasterService _priorityLevelMaster;
        public OutlierQueueInController(IOutlierQueueInService oulierQueueIn, IPatientService patientService,
            IPriorityLevelMasterService priorityLevelMaster)
        {
            _oulierQueueIn = oulierQueueIn;
            _patientService = patientService;
            _priorityLevelMaster = priorityLevelMaster;
        }
        [HttpGet(nameof(GetOutlierQueueIn))]
        public IActionResult GetOutlierQueueIn(int id)
        {
            var GetOutlierQueueInData = _oulierQueueIn.GetOutlierQueueIn(id);
            if (GetOutlierQueueInData is not null)
            {
                OutlierQueueInModel outlierQueueInModel = new OutlierQueueInModel()
                {
                    OutlierQueueId = GetOutlierQueueInData.Id,
                    Patient = _patientService.GetPatient(GetOutlierQueueInData.Patient_Id),
                    Priority_Level = _priorityLevelMaster.GetPriorityLevel(GetOutlierQueueInData.Priority_Level_id),
                    Start_Datetime = GetOutlierQueueInData.Start_Datetime,
                    //CreatedDate = GetOutlierQueueInData.CreatedDate,
                    //ModifiedDate = GetOutlierQueueInData.ModifiedDate,
                    //IsActive = GetOutlierQueueInData.IsActive
                };
                return Ok(outlierQueueInModel);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetListOutlierQueueIn))]
        public IActionResult GetListOutlierQueueIn()
        {
            var result = _oulierQueueIn.GetListOutlierQueueIn();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPost(nameof(InsertOutlierQueueInComment))]
        public ResponseFormatDto InsertOutlierQueueInComment([FromBody] OutlierQueueInCommentDto outlierQueueInCommentDto)
        {
            _oulierQueueIn.InsertOutlierQueueInComment(outlierQueueInCommentDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }

        [HttpGet(nameof(GetOutlierQueueInCommentById))]
        public ResponseFormatDto GetOutlierQueueInCommentById(int OutlierQueueInId)
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _oulierQueueIn.GetOutlierQueueInCommentById(OutlierQueueInId);

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
