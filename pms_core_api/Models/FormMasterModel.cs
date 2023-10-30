using System;
using DomainLayer.Models;

namespace pms_core_api.Models
{
    public class FormMasterModel
    {
        public IList<HospitalLocationMaster> locationMaster { get; set; }
        public IList<SpecialityMaster> specialityMaster { get; set; }
        public IList<PriorityLevelMaster> priorityLevelMaster { get; set; }
        public IList<referal_status_Master> ICU_care_Status { get; set; }

    }
}

