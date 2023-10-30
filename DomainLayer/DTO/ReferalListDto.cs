using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class ReferalListDto
    {
        public int ReferalID { get; set; }
        public int ReferalStatusId { get; set; }
        public string ReferalStatus { get; set; }
        public string Comment { get; set; }
        public DateTime StartDatetime { get; set; }
        public string PatientName { get; set; }
        public string HospitalNumber { get; set; }
        public int Age { get; set; }
        public string ProvisionalDiagnosis { get; set; }
        public string PreviousMedicalSurgicalHistory { get; set; }
        public int PatientId { get; set; }
        public string LevelOfCare { get; set; }
        public int OrderBy { get; set; }
    }
}
