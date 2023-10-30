using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using Serviceslayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Logics
{
    public class HospitalWardLocationMasterService : IHospitalWardLocationMasterService
    {
        private IRepository<hospital_Ward_Location_Master> _repository;
        public HospitalWardLocationMasterService(IRepository<hospital_Ward_Location_Master> repository)
        {
            _repository = repository;
        }
        public IEnumerable<hospital_Ward_Location_Master> GetAllHospitalWardLocation()
        {
            return _repository.GetAll();
        }
        public hospital_Ward_Location_Master GetHospitalWardLocationByWardId(int wardId)
        {
            return _repository.Get(wardId);
        }
    }
}
