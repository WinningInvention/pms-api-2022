using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class ZoneTypeMaster : BaseEntityModified
    {
        public int ZoneTypeId { get; set; }
        public string ZoneType { get; set; }
    }
}
