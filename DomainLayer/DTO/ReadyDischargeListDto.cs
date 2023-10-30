
namespace DomainLayer.DTO
{
    public class ReadyDischargeListDto
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string CurrentLocation { get; set; }
        public string DischargeOutcome { get; set; }
        public string PredictedDateTime { get; set; }
        public string StartDatetime { get; set; }
        public int NumberOfDays { get; set; }
        public string? Destination { get; set; }
        public string? ConsultantName { get; set; }
    }
}
