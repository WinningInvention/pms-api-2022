using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface ISpecialityMasterService
    {
        IEnumerable<SpecialityMaster> GetAllSpecialityMaster();
        SpecialityMaster GetSpecialityMaster(int id);
    }
}
