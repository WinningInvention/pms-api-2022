using DomainLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Serviceslayer.Interfaces;
using System.Net;

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutlierOutController : Controller
    {
        private readonly IOutlierOutService _outlierOutService;

        public OutlierOutController(IOutlierOutService outlierOutService)
        {
            _outlierOutService = outlierOutService;
        }

        [HttpGet(nameof(GetOutlierOutList))]
        public ResponseFormatDto GetOutlierOutList()
        {
            ResponseFormatDto responseFormatDto = new();
            var result = _outlierOutService.GetListOutlierQueueIn();

            if (result is not null)
            {
                responseFormatDto.statusCode = (int)HttpStatusCode.Accepted;
                responseFormatDto.data = result;
                return responseFormatDto;
            }
            return responseFormatDto;
        }

        [HttpPost(nameof(InsertOutlierOutQueueComment))]
        public ResponseFormatDto InsertOutlierOutQueueComment([FromBody] OutlierOutQueueCommentDto outlierOutQueueCommentDto)
        {
            _outlierOutService.InsertOutlierOutQueueComment(outlierOutQueueCommentDto);
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            responseFormatDto.statusCode = (int)HttpStatusCode.Created;
            responseFormatDto.message = "Data saved successfully.";
            return responseFormatDto;
        }

        [HttpGet(nameof(GetOutlierOutQueueCommentById))]
        public ResponseFormatDto GetOutlierOutQueueCommentById(int outlierOutQueueId)
        {
            ResponseFormatDto responseFormatDto = new ResponseFormatDto();
            var result = _outlierOutService.GetOutlierOutQueueCommentById(outlierOutQueueId);

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
