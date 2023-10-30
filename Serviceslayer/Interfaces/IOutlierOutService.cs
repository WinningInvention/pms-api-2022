using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{

    public interface IOutlierOutService
    {
        public IEnumerable<OutlierOutListDto> GetListOutlierQueueIn();
        void InsertOutlierOutQueueComment(OutlierOutQueueCommentDto outlierOutQueueCommentDto);
        IEnumerable<OutlierOutQueueCommentDto> GetOutlierOutQueueCommentById(int outlierOutQueueId);
    }
}
