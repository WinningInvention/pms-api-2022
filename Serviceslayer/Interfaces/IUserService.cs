using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        void InsertUser(User UserData);
        IEnumerable<User> GetAllUser();
    }
}
