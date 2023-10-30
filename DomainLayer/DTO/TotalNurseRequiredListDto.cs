using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class TotalNurseRequiredListDto
    {
        public int NurseRequiredFirstShift { get; set; }
        public int NurseRequiredSecondShift { get; set; }
        public int NurseAvailableFirstShift { get; set; }
        public int NurseAvailableSecondShift { get; set; }
        public DateTime Date { get; set; }
    }
}

