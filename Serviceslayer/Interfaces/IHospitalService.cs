using System;
using DomainLayer.Models;

namespace Serviceslayer.Interfaces
{
    public interface IHospitalService
    {
        IEnumerable<Hospital> GetAllHospital();
        Hospital GetHospital(int id);
        void InsertHospital(Hospital hospital);
        void UpdateHospital(Hospital hospital);
        void DeleteHospital(int id);
    }
}

