using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class OutlierOutQueueComment:BaseEntityModified
    {
        public int OutlierOutQueueCommentId { get; set; }
        public int OutlierOutQueueId { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
    }
}
