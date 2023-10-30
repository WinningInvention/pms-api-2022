using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class OutlierQueue_In :BaseEntity
    {
        public int Patient_Id { get; set; }
        public int Priority_Level_id { get; set; }
        public DateTime Start_Datetime { get; set; }
    }
}
