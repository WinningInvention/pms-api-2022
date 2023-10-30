using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
   public class NurseAvailabilityDto
    {
        public DateTime AvailabilityDate { get; set; }
        public int FirstShift { get; set; }
        public int SecondShift { get; set; }
    }
}
