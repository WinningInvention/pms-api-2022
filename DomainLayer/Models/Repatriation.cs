

namespace DomainLayer.Models
{
    public class Repatriation :BaseEntity
    {
        public int Patient_Id { get; set; }
        public bool Is_Repatriation { get; set; }
        public string RepatType { get; set; }
        public string RepatHospitalName { get; set; }
        public string RepatConsultantName { get; set; }
    }
}
