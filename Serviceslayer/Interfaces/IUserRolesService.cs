using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IUserRolesService
    {
        Task AddEmployeeRoles(string Email, string RoleName);
        //Task DeleteEmployeeRoles(int EmployeeDetailId, string RoleName);
       /// Task<IEnumerable<string>> GetEmployeeRolesByEmployeeId(int EmployeeDetailId);
    }
}
