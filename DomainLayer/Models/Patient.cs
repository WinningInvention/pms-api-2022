using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Patient : BaseEntity
    {

        public string Hospital_Number { get; set; }
        public string NHS_Number { get; set; }
        public string Name { get; set; }
        public string Post_Code { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string health_board { get; set; }
        public bool Repatriation { get; set; }
        public int Hospital_Location_Id { get; set; }
        public string Another_Hospital { get; set; }
        public int Admitting_consultant_name_Id { get; set; }
        public string Organ_Support_requirements { get; set; }
        public bool IsCardiff { get; set; }
        public bool IsSpecialist { get; set; }
        public int Speciality_Id { get; set; }
        public int Hospital_id { get; set; }
        public string Provisional_diagnosis { get; set; }
        public int Priority_Level_Id { get; set; }
        public int Ward_Location_ID { get; set; }
        public string Hospital_Ward_Location { get; set; }

        public string ProvisionalDiagnosisSecondary { get; set; }



        //public bool Repatriation_from_other_hospital { get; set; }
        //public string ICU_care_Status { get; set; }
        //public string ICU_Care { get; set; }
        //public string Infection_Control_Information { get; set; }
        //public string Previous_Medical { get; set; }
        //public string Level_of_ICU_care_required { get; set; }
        //public string Referring_Staff_name { get; set; }
        //public string Admitting_consultant_name { get; set; }

        //public string Infection_control_info { get; set; }
        //public string Hospital_area { get; set; } 
    }
}
