using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class ReferalComment : BaseEntityModified
    {
        public int ReferalCommentId { get; set; }
        public int ReferalId { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
    }
}
