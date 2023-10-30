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
    public class SpecialityMasterService : ISpecialityMasterService
    {
        private IRepository<SpecialityMaster> _repository;
        public SpecialityMasterService(IRepository<SpecialityMaster> repository)
        {
            _repository = repository;
        }

        public IEnumerable<SpecialityMaster> GetAllSpecialityMaster()
        {
            return _repository.GetAll();
        }

        public SpecialityMaster GetSpecialityMaster(int id)
        {
            return _repository.Get(id);
        }
    }
}
