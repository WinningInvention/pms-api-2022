using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatient();
        Patient GetPatient(int id);

        void UpdatePatientDetails(UpdatePatientDetailsDto updatePatientDetailsDto);
    }
}
