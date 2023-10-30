using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IPriorityLevelMasterService
    {
        IEnumerable<PriorityLevelMaster> GetAllPriorityLevel();
        PriorityLevelMaster GetPriorityLevel(int id);
    }
}
