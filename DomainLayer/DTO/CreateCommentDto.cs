using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class CreateCommentDto : BaseEntity
    {
        public string Comment { get; set; }
        public int ReferalStatusId { get; set; }
        public int ReferalId { get; set; }
    }
}
