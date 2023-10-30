using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class OutlierQueueInDto
    {
        public int OutlierQueueInId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int PriorityLevelid { get; set; }
        public string PriorityLevel { get; set; }
        public bool IsActive { get; set; }
        public string StartDatetime { get; set; }
        public int NumberOfDays { get; set; }
        public string ProvisionalDiagnosis { get; set; }
        public string OrganSupportRequired { get; set; }
    }
}
