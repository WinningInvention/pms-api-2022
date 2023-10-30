using DomainLayer.Models;

namespace pms_core_api.Models
{
    public class OutlierQueueInModel
    {
        public int OutlierQueueId { get; set; }
        public Patient Patient { get; set; }
        public PriorityLevelMaster Priority_Level { get; set; }
        public DateTime Start_Datetime { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public bool IsActive { get; set; }

    }
}
