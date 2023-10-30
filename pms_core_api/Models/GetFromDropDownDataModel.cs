using DomainLayer.DTO;
using DomainLayer.Models;

namespace pms_core_api.Models
{
    public class GetFromDropDownDataModel
    {
        public IList<referal_status_Master> ICU_care_Status { get; set; }//Referal table referal_status_id
        public IList<HospitalLocationMaster> locationMaster { get; set; } //Patient table - Hospital_Location_Id
        public IList<SpecialityMaster> specialityMaster { get; set; }//Patient table - Speciality_Id
        public IList<PriorityLevelMaster> priorityLevelMaster { get; set; }//Patient table - Priority_Level_Id
        public IList<User> Admitting_consultant_name { get; set; } //Patient table - Admitting_consultant_name_Id
        public IList<InfectionListDto> lstInfectionControlMaster { get; set; } //Patient table - Admitting_consultant_name_Id
    }
}
