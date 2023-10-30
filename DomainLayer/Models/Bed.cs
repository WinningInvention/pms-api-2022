using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Bed : BaseEntityModified
    {
        public int BedId { get; set; }
        public int BedNumber { get; set; }
        public int ZoneId { get; set; }
    }
}
