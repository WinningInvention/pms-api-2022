using System;
using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repository;
using Serviceslayer.Interfaces;

namespace Serviceslayer.Logics
{
    public class HospitalService : IHospitalService
    {
        private IRepository<Hospital> _repository;

        public HospitalService(IRepository<Hospital> repository)
        {
            _repository = repository;
        }

        public void DeleteHospital(int id)
        {
            Hospital hospital = GetHospital(id);
            _repository.Remove(hospital);
            _repository.SaveChanges();
        }

        public IEnumerable<Hospital> GetAllHospital()
        {
            return _repository.GetAll();
        }

        public Hospital GetHospital(int id)
        {
            return _repository.Get(id);
        }

        public void InsertHospital(Hospital hospital)
        {
            _repository.Insert(hospital);
        }

        public void UpdateHospital(Hospital hospital)
        {
            _repository.Update(hospital);
        }
    }
}

