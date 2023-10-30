using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PatientBed : BaseEntityModified
    {
        public int PatientBedId { get; set; }
        public int PatientId { get; set; }
        public int BedId { get; set; }
        public DateTime AllocationDatetime { get; set; }
        public int NurseId { get; set; }
        public DateTime ? DischargeDatetime { get; set; }
        public DateTime ? PredictedDatetime { get; set; }
        public bool IsDischarged { get; set; }
        public int DischargeTypeId { get; set; }
        public string? ClinicalRequirements { get; set; }
        public bool IsReadyDischarge { get; set; }
        public string DischargeOutcome { get; set; }
        public string CurrentLocation { get; set; }
        public string Destination { get; set; }
        public string ConsultantName { get; set; }
        public string Comment { get; set; }
    }
}
