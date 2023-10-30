using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repository;
using Serviceslayer.Interfaces;
using System;

namespace Serviceslayer.Logics
{
    public class HospitalLocationMasterService : IHospitalLocationMasterService
    {
        private readonly IRepository<HospitalLocationMaster> _repository;
        public HospitalLocationMasterService(IRepository<HospitalLocationMaster> repository)
        {
            _repository = repository;
        }
        public IEnumerable<HospitalLocationMaster> GetAllHospitaLocation()
        {
            return _repository.GetAll();
        }
        public HospitalLocationMaster GetHospitalLocation(int id)
        {
            return _repository.Get(id);
        }
    }
}
