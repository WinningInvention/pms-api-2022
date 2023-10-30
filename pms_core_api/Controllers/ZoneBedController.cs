using Microsoft.AspNetCore.Mvc;
using Serviceslayer.Interfaces;
using DomainLayer.Models;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Cors;
using System.Net;

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("PMSPolicy")]
    public class ZoneBedController : Controller
    {
        private readonly IZoneBedService _zoneBedService;
        public ZoneBedController(IZoneBedService zoneBedService)
        {
            _zoneBedService = zoneBedService;
        }


        [HttpPost(nameof(InsertZoneBed))]
        public IActionResult InsertZoneBed([FromBody] Zone zone)
        {
            bool submitflag = _zoneBedService.InsertZoneBed(zone);

            if (submitflag == true) return Ok("Insert success");
            else return BadRequest("Insert not success");
        }

        [HttpGet(nameof(GetPatientBed))]
        public IActionResult GetPatientBed(int ZoneId)
        {
            var result = _zoneBedService.GetAllPatientBed(ZoneId);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpPost(nameof(InsertPatientBed))]
        public IActionResult InsertPatientBed([FromBody] List<AllocatePatientBedDto> patientBedDtos)
        {
            _zoneBedService.InsertPatientBed(patientBedDtos);
            return Ok("Data inserted");
        }
        [HttpGet(nameof(GetAllZone))]
        public IActionResult GetAllZone(int ZoneId)
        {
            var result = _zoneBedService.GetAllZone();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpGet(nameof(GetZoneBed))]
        public IActionResult GetZoneBed(int ZoneId)
        {
            var result = _zoneBedService.GetAvailableBedByZone(ZoneId);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }
        [HttpPost(nameof(UpdateZoneBed))]
        public IActionResult UpdateZoneBed([FromBody] ZoneUpdateDto zone)
        {
            bool submitflag = _zoneBedService.UpdateZoneBed(zone);

            if (submitflag == true) return Ok("Update success");
            else return BadRequest("Update not success");
        }
        [HttpPost(nameof(DeleteZoneBed))]
        public IActionResult DeleteZoneBed(int zoneId)
        {
            bool submitflag = _zoneBedService.DeleteZoneBed(zoneId);

            if (submitflag == true) return Ok("Delete success");
            else return BadRequest("Delete not success");
        }
              
        [HttpPost(nameof(MovePatient))]
        public IActionResult MovePatient([FromBody] MovePatientDto movePatient)
        {
            bool submitflag = _zoneBedService.MovePatient(movePatient);

            if (submitflag == true) return Ok("Move success");
            else return BadRequest("Move not success");
        }

        [HttpGet(nameof(ZoneBedBirdView))]
        public ResponseFormatDto ZoneBedBirdView()
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _zoneBedService.GetZoneBedBirdView();

            if (result is not null)
            {
                responseFormatDto.statusCode = (int)HttpStatusCode.Accepted;
                responseFormatDto.data = result;
                return responseFormatDto;
            }
            return responseFormatDto;
        }

        [HttpPost(nameof(InsertOrUpdatePatientBedComment))]
        public IActionResult InsertOrUpdatePatientBedComment([FromBody] AddCommentPatientBedDto addCommentPatientBedDto)
        {
            _zoneBedService.InsertOrUpdatePatientBedComment(addCommentPatientBedDto);
            return Ok("Comment inserted or updated");
        }

        [HttpGet(nameof(GetCommentByPatientBedId))]
        public IActionResult GetCommentByPatientBedId(int PatientBedId)
        {
            var result = _zoneBedService.GetCommentByPatientBedId(PatientBedId);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        //Added comment to test commit and push after deleting debug, bin and object folders.

    }
}
