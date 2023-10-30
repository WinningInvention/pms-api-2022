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
    public class ReferalStatusMasterService : IReferalStatusMasterService
    {
        private IRepository<referal_status_Master> _repository;
        public ReferalStatusMasterService(IRepository<referal_status_Master> repository)
        {
            _repository = repository;
        }
        public IEnumerable<referal_status_Master> GetAllReferalStatus()
        {
            return _repository.GetAll();
        }

        public referal_status_Master GetReferalStatus(int id)
        {
            return _repository.Get(id);
        }
    }
}
