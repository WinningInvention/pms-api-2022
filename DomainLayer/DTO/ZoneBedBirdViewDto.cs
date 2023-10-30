using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class ZoneBedBirdViewDto
    {
        public ZoneBedBirdViewDto()
        {
            PatientBedList = new List<PatientBedDto>();
        }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public List<PatientBedDto> PatientBedList { get; set; }
    }
}
