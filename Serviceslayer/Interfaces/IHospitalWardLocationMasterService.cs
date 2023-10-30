using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IHospitalWardLocationMasterService
    {
        IEnumerable<hospital_Ward_Location_Master> GetAllHospitalWardLocation();
        hospital_Ward_Location_Master GetHospitalWardLocationByWardId(int wardId);
    }
}
