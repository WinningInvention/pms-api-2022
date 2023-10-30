using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class referal_status_Master :BaseEntity
    {
        public string Status { get; set; }
        public int OrderBy { get; set; }
    }
}
