using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class UpdateNurseAvailablityDto
    {
        public int NurseAvailablityId { get; set; }
        public int FirstShift { get; set; }
        public int SecondShift { get; set; }
    }
}
