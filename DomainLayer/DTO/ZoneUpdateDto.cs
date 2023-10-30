using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class ZoneUpdateDto
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int TotalBeds { get; set; }
    }
}
