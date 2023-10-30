using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IInfectionControlMasterService
    {
        void InsertInfectionControl(InfectionControlInsertDto infectionControlInsertDto);
        IList<InfectionListDto> GetInfectionControlList();
    }
}
