using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using Serviceslayer.Interfaces;

namespace Serviceslayer.Logics
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;
        private readonly IRepositoryModified<PatientBed> _patientBedrepository;
        public PatientService(IRepository<Patient> repository, IRepositoryModified<PatientBed> patientBedrepository)
        {
            _repository = repository;
            _patientBedrepository = patientBedrepository;
        }
        public IEnumerable<Patient> GetAllPatient()
        {
            return _repository.GetAll();
        }
        public Patient GetPatient(int id)
        {
            return _repository.Get(id);
        }
        public void UpdatePatientDetails(UpdatePatientDetailsDto updatePatientDetailsDto)
        {
            var patient = _repository.Get(x => x.Id == updatePatientDetailsDto.PatientId);
            patient.Provisional_diagnosis = updatePatientDetailsDto.Provisional_diagnosis;
            patient.Priority_Level_Id = updatePatientDetailsDto.Priority_Level_Id;
            patient.IsSpecialist = updatePatientDetailsDto.IsSpecialist;
            _repository.Update(patient);

            var patientBed = _patientBedrepository.Get(x => x.PatientBedId == updatePatientDetailsDto.PatientBedId);
            patientBed.PredictedDatetime = updatePatientDetailsDto.PredictedDatetime;
            patientBed.ClinicalRequirements = updatePatientDetailsDto.ClinicalRequirements;
            _patientBedrepository.Update(patientBed);            
        }
    }
}
