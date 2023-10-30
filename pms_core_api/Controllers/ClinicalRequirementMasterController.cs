using DomainLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Serviceslayer.Interfaces;
using Serviceslayer.Logics;
using System.Net;

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicalRequirementMasterController : Controller
    {
        private readonly IClinicalRequirementMasterService _clinicalRequirementMasterService;

        public ClinicalRequirementMasterController(IClinicalRequirementMasterService clinicalRequirementMasterService)
        {
            _clinicalRequirementMasterService = clinicalRequirementMasterService;
        }
        [HttpPost(nameof(InsertClinicalRequirement))]
        public ResponseFormatDto InsertClinicalRequirement([FromBody] ClinicalRequirementMasterDto clinicalRequirementMasterDto)
        {
            _clinicalRequirementMasterService.InsertClinicalRequirement(clinicalRequirementMasterDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }

        [HttpGet(nameof(GetClinicalRequirement))]
        public ResponseFormatDto GetClinicalRequirement()
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _clinicalRequirementMasterService.GetClinicalRequirement();

            if (result is not null)
            {
                responseFormatDto.statusCode = (int)HttpStatusCode.Accepted;
                responseFormatDto.data = result;
                return responseFormatDto;
            }
            return responseFormatDto;
        }
        [HttpPost(nameof(AddUpdateClinicalRequirement))]
        public ResponseFormatDto AddUpdateClinicalRequirement([FromBody] AddClinicalRequirementsDto addClinicalRequirementsDto)
        {
            _clinicalRequirementMasterService.AddUpdateClinicalRequirement(addClinicalRequirementsDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }
    }
}
