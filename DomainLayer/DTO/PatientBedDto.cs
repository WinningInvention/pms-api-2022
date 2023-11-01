using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class PatientBedDto
    {
        public int BedId { get; set; }
        public int BedNumber { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int PatientBedId { get; set; }
        public int? PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime AllocationDatetime { get; set; }
        public  DateTime ? DischargeDatetime { get; set; }
        public  DateTime ? PredictedDatetime { get; set; }
        public string PredictedDatetimeString { get; set; }
        public int NurseId { get; set; }
        public bool IsDischarged { get; set; }
        public int DischargeTypeId { get; set; }
        public string Provisionaldiagnosis { get; set; }
        public bool? IsCardiff { get; set; }
        public bool? IsSpecialist { get; set; }
        public string PriorityLevelStatus { get; set; }
        public int PriorityLevelID { get; set; }
        public int? TotalICUDays { get; set; }
        public string ClinicalRequirements { get; set; }
        public string HealthBoard { get; set; }
        public string HospitalNumber { get; set; }
        public string SpecialityName { get; set; }
        public int SpecialityID { get; set; }
        public bool? IsReadytoDischarge { get; set; }

        public int Age { get; set; }
        public string PatientHospitalNumber { get; set; }
        public string? DischargeOutcome { get; set; }
        public string? CurrentLocation { get; set; }
        public string HandOverComment { get; set; }

    }
}
