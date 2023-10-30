using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Serviceslayer.Interfaces;
using Serviceslayer.Logics;
using System.Net;

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseTrackingController : Controller
    {

        private readonly INurseTrackingService _nurseTrackingService;
        public NurseTrackingController(INurseTrackingService nurseTrackingService)
        {
            _nurseTrackingService = nurseTrackingService;
        }

        [HttpPost(nameof(InsertAvailableNurse))]
        public ResponseFormatDto InsertAvailableNurse([FromBody] List<NurseAvailabilityDto> nurseAvailabilityDto)
        {
            _nurseTrackingService.InsertAvailableNurse(nurseAvailabilityDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }

        [HttpGet(nameof(GetAllNurse))]
        public ResponseFormatDto GetAllNurse()
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _nurseTrackingService.GetAllNurse();

            if (result is not null)
            {
                responseFormatDto.statusCode = (int)HttpStatusCode.Accepted;
                responseFormatDto.data = result;                
                return responseFormatDto;
            }
            return responseFormatDto;
        }

        [HttpPost(nameof(UpdateNurseAvailability))]
        public ResponseFormatDto UpdateNurseAvailability([FromBody] UpdateNurseAvailablityDto updateNurseAvailablityDto)
        {
            _nurseTrackingService.UpdateNurseAvailability(updateNurseAvailablityDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }

        [HttpGet(nameof(GetRequiredNurseForWeek))]
        public ResponseFormatDto GetRequiredNurseForWeek()
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _nurseTrackingService.GetTotalRequiredNurseByDate();

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
