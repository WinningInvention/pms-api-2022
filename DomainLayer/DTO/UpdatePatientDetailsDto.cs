using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class UpdatePatientDetailsDto
    {
        public int PatientId { get; set; }
        public string Provisional_diagnosis { get; set; }
        public int Priority_Level_Id { get; set; }
        public bool IsSpecialist { get; set; }
        public int PatientBedId { get; set; }
        public DateTime? PredictedDatetime { get; set; }
        public string ClinicalRequirements { get; set; }
    }
}
