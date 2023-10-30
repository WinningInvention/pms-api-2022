using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Zone : BaseEntityModified
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int TotalBeds { get; set; }
        public int ZoneTypeId { get; set; }
        public int HospitalId { get; set; }

    }
}
