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
    public class UserService : IUserService
    {
        private IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public User GetUserById(int id)
        {
            return _repository.Get(id);
        }
        public IEnumerable<User> GetAllUser()
        {
            return _repository.GetAll();
        }
        public void InsertUser(User userdata)
        {
            _repository.Insert(userdata);
        }

    }
}
