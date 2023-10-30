using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IReferalStatusMasterService
    {
        IEnumerable<referal_status_Master> GetAllReferalStatus();
        referal_status_Master GetReferalStatus(int id);
    }
}
