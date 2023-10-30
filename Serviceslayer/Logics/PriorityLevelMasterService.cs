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
    public class PriorityLevelMasterService : IPriorityLevelMasterService
    {
        private IRepository<PriorityLevelMaster> _repository;
        public PriorityLevelMasterService(IRepository<PriorityLevelMaster> repository)
        {
            _repository = repository;
        }
        public IEnumerable<PriorityLevelMaster> GetAllPriorityLevel()
        {
            return _repository.GetAll();
        }

        public PriorityLevelMaster GetPriorityLevel(int id)
        {
            return _repository.Get(id);
        }
    }
}
