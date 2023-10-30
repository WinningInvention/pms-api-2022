using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class NurseAvailabilityTracking:BaseEntityModified
    {
        public int NurseAvailabilityTrackingId { get;set;}
        public int NurseAvailablityId { get; set; }
        public DateTime AvailabilityDate { get; set; }
        public int FirstShift { get; set; }
        public int SecondShift { get; set; }
    }
}
