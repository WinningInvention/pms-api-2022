using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
   public interface INurseTrackingService
    {
        void InsertAvailableNurse(List<NurseAvailabilityDto> nurseAvailabilityDto);
        IEnumerable<UpdateNurseAvailablityDto> GetById(int id);
        IEnumerable<NurseAvailability> GetAllNurse();
        void UpdateNurseAvailability(UpdateNurseAvailablityDto availableNurse);
        IEnumerable<TotalNurseRequiredListDto> GetTotalRequiredNurseByDate();

    }
}
