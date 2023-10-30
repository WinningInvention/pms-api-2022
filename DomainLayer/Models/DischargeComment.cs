using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class DischargeComment: BaseEntityModified
    {
        public int DischargeCommentId { get; set; }
        public int DischargeId { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
    }
}
