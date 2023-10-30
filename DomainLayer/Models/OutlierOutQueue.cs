using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class OutlierOutQueue:BaseEntityModified
    {
        public int OutlierOutQueueId { get; set; }
        public int PatientBedId { get; set; }
        public int PatientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get;set; }
    }
}
