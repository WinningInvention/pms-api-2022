using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IReferalmasterService
    {
        Referal GetReferal(int id);
        IEnumerable<ReferalListDto> GetListReferal();
        void InsertComment(CreateCommentDto comment);
        IEnumerable<CommentListDto> GetReferalCommentById(int ReferalId);
        public IEnumerable<RepatrationListDto> GetListRepatration();
    }
}
