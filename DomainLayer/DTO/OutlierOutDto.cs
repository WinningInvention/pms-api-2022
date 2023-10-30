using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class OutlierOutListDto
    {
        public int OutlierOutQueueId { get; set; }
        public int PatientId { get; set; }

        public int PatientBedId { get; set; }
        public string PatientName { get; set; }
        public int PriorityLevelid { get; set; }
        public string StartDatetime { get; set; }
        public int NumberOfDays { get; set; }
        public string PriorityLevel { get; set; }
        public string CurrentLocation { get; set; }
        public string Destination { get; set; }
        public string ConsultantName { get; set; }

        public string PredicatedDateTime { get; set; }

        public string Zone { get; set; }
        public int BedNumber { get; set; }

    }
}
