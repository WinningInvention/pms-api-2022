using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
   public class OutlierQueueInComment: BaseEntityModified
    {
        public int OutlierQueueInCommentId { get; set; }
        public int OutlierQueueInId { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }

    }
}
