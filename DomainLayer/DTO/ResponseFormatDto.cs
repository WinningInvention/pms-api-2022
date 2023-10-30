using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class ResponseFormatDto
    {
        public int statusCode { get; set; }
        public object data { get; set; }
        public string message { get; set; }
        public Error error { get; set; }
    }

    public class Error
    {
        public bool isError { get; set; }
        public int statusCode { get; set; }
        public string exceptionMessage { get; set; }
        public string details { get; set; }
        public string errorId { get; set; }
    }
}
