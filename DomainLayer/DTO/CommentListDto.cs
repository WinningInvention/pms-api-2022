using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class CommentListDto
    {
        public int ReferalCommentId { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
