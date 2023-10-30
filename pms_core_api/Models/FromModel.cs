using DomainLayer.Models;

namespace pms_core_api.Models
{
    public class FromModel
    {
        public string Hospital_Number { get; set; }//Patient table - Hospital_Number
        public string NHS_Number { get; set; }//Patient table - NHS_Number
        public string Name { get; set; }//Patient table - Name
        public int Age { get; set; }//Patient table - Age
        public string Gender { get; set; }//Patient table - Gender
        public DateTime DOB { get; set; }//Patient table - DOB
        public string Post_Code { get; set; }//Patient table - Postal Code
        public string health_board { get; set; }//Patient table - Health board
        public bool Repatriation { get; set; }//Patient table - Repatriation
        public int locationMaster_id { get; set; } //Patient table - Hospital_Location_Id
        public string Another_Hospital { get; set; }//Patient table -Another_Hospital
        public int specialityMaster_id { get; set; }//Patient table - Speciality_Id
        public int Admitting_consultant_name_Id { get; set; } //Patient table - Admitting_consultant_name_Id && Aicu_Patient_Form_Details - Consultant_Id
        public string Referring_Staff_name { get; set; }// Aicu_Patient_Form_Details - Referring_staff_name
        public string Provisional_diagnosis { get; set; }// Patient - Provisional_diagnosis
        
        public int priorityLevelMaster_id { get; set; }//Patient table - Priority_Level_Id
        public string Organ_Support_requirements { get; set; }///Patient table -Organ_Support_requirements
        public string Previous_Medical { get; set; }//  Aicu_Patient_Form_Details - Previous_medical_surgical_History

        public string Infection_Control_Information { get; set; }//  Aicu_Patient_Form_Details - Infection_control_info
        public bool ICU_Care { get; set; }//Patient table (IsSpecialist)
        public bool Hospital_area { get; set; }//Patient table  (IsCardiff)
        public int ICU_care_Status_id { get; set; }//Referal table referal_status_id 
        //public DateTime created_date { get; set; }//Patient table 
        //public DateTime modified_date { get; set; }//Patient table 
        //public bool is_active { get; set; }//Patient table 
        public int Hospital_id { get; set; }//Patient table 
        public int Ward_Location_ID { get; set; }//Patient table 
        public string Hospital_Ward_Location { get; set; }//Patient table 
        public string? ProvisionalDiagnosisSecondary { get; set; } //Patient table
        public string? RepatHospitalName { get; set; }
        public string? RepatType { get; set; }
        public string? RepatConsultantName { get; set; }
        public int? InfectionControlID { get; set; }

    }
}
