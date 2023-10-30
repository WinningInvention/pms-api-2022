using System;
using DomainLayer.Models;

namespace Serviceslayer.Interfaces
{
    public interface IHospitalLocationMasterService
    {
        IEnumerable<HospitalLocationMaster> GetAllHospitaLocation();
        HospitalLocationMaster GetHospitalLocation(int id);
    }
}
