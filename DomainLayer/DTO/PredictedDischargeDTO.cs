using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class PredictedDischargeDTO
    {
        public int PatientBedId { get; set; }
        public DateTime? PredictedDatetime { get; set; }
    }
}
