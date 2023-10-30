using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Referal: BaseEntity
    {
        public int Patient_Id { get; set; }
        public int Referal_Status_Id { get; set; }
        public string Comment { get; set; }
        public DateTime Start_Datetime { get; set; }

    }
}
