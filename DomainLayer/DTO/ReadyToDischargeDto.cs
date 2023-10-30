using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class ReadyToDischargeDto
    {
        public int PatientBedId { get; set; }
        public bool IsPACKOorRecovery { get; set; }
        public string DischargeOutcome { get; set; }
        public string CurrentLocation { get; set; }
        public string? Destination { get; set; }
        public string? ConsultantName { get; set; }
    }
}
