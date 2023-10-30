using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IOutlierQueueInService
    {
        IEnumerable<OutlierQueue_In> GetAllOutlierQueueIn();
        OutlierQueue_In GetOutlierQueueIn(int id);
        public IEnumerable<OutlierQueueInDto> GetListOutlierQueueIn();
        void InsertOutlierQueueInComment(OutlierQueueInCommentDto outlierQueueInCommentDto);
        IEnumerable<OutlierQueueInCommentDto> GetOutlierQueueInCommentById(int OutlierQueueInId);
    }
}
