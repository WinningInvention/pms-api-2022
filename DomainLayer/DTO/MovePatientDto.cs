using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
   public class MovePatientDto
    {
        public int PatientBedId { get; set; }
        public int BedId { get; set; }
     }
}
