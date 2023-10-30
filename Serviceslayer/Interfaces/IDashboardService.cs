using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IDashboardService
    {
        IEnumerable<OccupyVacantBedDto> GetOccupyVaccantBed();
        IEnumerable<L2L3PateintCountDto> GetL2L3PatientCount();
        GetCardiffDto GetCardiffCount();
        GetSpecialistDto GetSpecialistDto();
    }
}
