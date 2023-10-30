using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class PredictedDischargeListDto
    {
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public int PatientBedId { get; set; }
        public string LevelOfCare { get; set; }
        public string Diagnosis { get; set; }
        public string PredictedDateTime { get; set; }
        public string StartDatetime { get; set; }
        public int NumberOfDays { get; set; }
    }
}
