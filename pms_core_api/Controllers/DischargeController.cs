using DomainLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Serviceslayer.Interfaces;
using Serviceslayer.Logics;
using System.Net;

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DischargeController : Controller
    {
        private readonly IDischargeService _dischargeService;
        public DischargeController(IDischargeService dischargeService)
        {
            _dischargeService=dischargeService;
        }

        [HttpPost(nameof(PredictedDischarge))]
        public ResponseFormatDto PredictedDischarge([FromBody] PredictedDischargeDTO predictedDischargeDTO)
        {
           _dischargeService.PredictedDated(predictedDischargeDTO);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }

        [HttpPost(nameof(ReadyToDischarge))]
        public ResponseFormatDto ReadyToDischarge([FromBody] ReadyToDischargeDto readyToDischargeDto)
        {
            _dischargeService.ReadyToDischarge(readyToDischargeDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }

        [HttpPost(nameof(FinalDischarge))]
        public ResponseFormatDto FinalDischarge([FromBody] PatientDischargeDto patientDischargeDto)
        {
            _dischargeService.FinalDischarge(patientDischargeDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }

        [HttpGet(nameof(PatientDischargeList))]
        public ResponseFormatDto PatientDischargeList()
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _dischargeService.GetPatientDischargeList();

            if (result is not null)
            {
                responseFormatDto.statusCode = (int)HttpStatusCode.Accepted;
                responseFormatDto.data = result;
                return responseFormatDto;
            }
            return responseFormatDto;
        }

        [HttpPost(nameof(InsertDischargeComment))]
        public ResponseFormatDto InsertDischargeComment([FromBody] DischargeCommentDto dischargeCommentDto)
        {
            _dischargeService.InsertDischargeComment(dischargeCommentDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }

        [HttpGet(nameof(GetDischargeCommentById))]
        public ResponseFormatDto GetDischargeCommentById(int dischargeId)
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _dischargeService.GetDischargeCommentById(dischargeId);

            if (result is not null)
            {
                responseFormatDto.statusCode = (int)HttpStatusCode.Accepted;
                responseFormatDto.data = result;
                return responseFormatDto;
            }
            return responseFormatDto;
        }

        [HttpGet(nameof(PredictedDischargeList))]
        public ResponseFormatDto PredictedDischargeList()
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _dischargeService.PredictedDischargeList();

            if (result is not null)
            {
                responseFormatDto.statusCode = (int)HttpStatusCode.Accepted;
                responseFormatDto.data = result;
                return responseFormatDto;
            }
            return responseFormatDto;
        }

        [HttpGet(nameof(ReadyDischargeList))]
        public ResponseFormatDto ReadyDischargeList()
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _dischargeService.ReadyDischargeList();

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
