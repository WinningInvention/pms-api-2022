using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PatientBedTracking:BaseEntityModified
    {
        public int PatientBedTrackingId { get; set; }
        public int PatientBedId { get; set; }
        public int BedId { get; set; }

    }
}
