using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class DischargeCommentDto
    {
        public int DischargeId { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
    }
}
