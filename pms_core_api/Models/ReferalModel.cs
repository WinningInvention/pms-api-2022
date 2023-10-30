using DomainLayer.Models;

namespace pms_core_api.Models
{
    public class ReferalModel
    {
        public int ReferalId { get; set; }
        public Patient PatientDetails { get; set; }
        public referal_status_Master ReferalStatus { get; set; }
        public string Comment { get; set; }
        public DateTime Start_Datetime { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public bool IsActive { get; set; }


    }
}
