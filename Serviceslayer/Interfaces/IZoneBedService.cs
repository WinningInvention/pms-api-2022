using DomainLayer.DTO;
using DomainLayer.Models;

namespace Serviceslayer.Interfaces
{
    public interface IZoneBedService
    {
        public bool InsertZoneBed(Zone zone);
        IEnumerable<PatientBedDto> GetAllPatientBed(int ZoneId);
        void InsertPatientBed(List<AllocatePatientBedDto> patientBeds);
        IEnumerable<AllZoneForBedDto> GetAllZone();
        IEnumerable<BedForZoneDto> GetAvailableBedByZone(int Zoneid);
        public bool UpdateZoneBed(ZoneUpdateDto zone);
        public bool DeleteZoneBed(int zoneid);
        public bool MovePatient(MovePatientDto movePatient);
        public IEnumerable<ZoneBedBirdViewDto> GetZoneBedBirdView();
    }
}
