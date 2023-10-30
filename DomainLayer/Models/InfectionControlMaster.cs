using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
   public class InfectionControlMaster:BaseEntityModified
    {
        public int InfectionControlId { get; set; }
        public string InfectionControlValue { get; set; }
    }
}
