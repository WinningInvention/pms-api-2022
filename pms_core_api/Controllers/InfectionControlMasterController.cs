using DomainLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Serviceslayer.Interfaces;
using Serviceslayer.Logics;
using System.Net;

namespace pms_core_api.Controllers
{
    public class InfectionControlMasterController : Controller
    {
        private readonly IInfectionControlMasterService _infectionControlMasterService;

        public InfectionControlMasterController(IInfectionControlMasterService infectionControlMasterService)
        {
            _infectionControlMasterService = infectionControlMasterService;
        }
        [HttpPost(nameof(InsertInfectionControl))]
        public ResponseFormatDto InsertInfectionControl([FromBody] InfectionControlInsertDto infectionControlInsertDto)
        {
            _infectionControlMasterService.InsertInfectionControl(infectionControlInsertDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }
        [HttpPost(nameof(GetInfectionControlList))]
        public ResponseFormatDto GetInfectionControlList()
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _infectionControlMasterService.GetInfectionControlList();

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
