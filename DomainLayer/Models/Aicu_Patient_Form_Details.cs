
namespace DomainLayer.Models
{
    public class Aicu_Patient_Form_Details : BaseEntity
    {
        public int Patient_Id { get; set; }
        public int Consultant_Id { get; set; }
        public string Referring_Staff_Name { get; set; }
        public int Clinical_Requirement_Id { get; set; }
        public string Previous_Medical_Surgical_History { get; set; }
        public int? InfectionControlID { get; set; }
        public string OtherIntectionControl { get; set; }
        public DateTime Referal_Date_Time { get; set; }

        
    }
}
