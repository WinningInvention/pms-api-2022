using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class RepatrationListDto
    {
        public int RepatriationID { get; set; }
        public string Comment { get; set; }
        public string CreatedDate { get; set; }
        public string PatientName { get; set; }
        public string HospitalNumber { get; set; }
        public int Age { get; set; }
        public string ProvisionalDiagnosis { get; set; }
        public string PreviousMedicalSurgicalHistory { get; set; }
        public int PatientId { get; set; }
        public string LevelOfCare { get; set; }
        public int OrderBy { get; set; }
        public string RepatHospitalName { get; set; }
        public string RepatType { get; set; }
    }
}
