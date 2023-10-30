using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class hospital_Ward_Location_Master :BaseEntity
    {
        public string Wards_Name { get; set; }
        public int Hospital_Locatio_Id { get; set; }
    }
}
