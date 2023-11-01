using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Serviceslayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Logics
{
    public class UserRolesService : IUserRolesService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesService(UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task AddEmployeeRoles(string Email, string RoleName)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Consultant))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Consultant));
            if (!await _roleManager.RoleExistsAsync(UserRoles.FloorCordinatior))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.FloorCordinatior));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Part))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Part));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Manager))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, RoleName);
            }
        }
        //public async Task DeleteEmployeeRoles(int EmployeeDetailId, string RoleName)
        //{
        //    var employee = await _employeeDetailsRepository.Get(x => x.EmployeeDetailId == EmployeeDetailId);
        //    var user = await _userManager.FindByEmailAsync(employee.Email);
        //    if (user != null)
        //    {
        //        await _userManager.RemoveFromRoleAsync(user, RoleName);
        //    }
        //}
        //public async Task<IEnumerable<string>> GetEmployeeRolesByEmployeeId(int EmployeeDetailId)
        //{
        //    var employee = await _employeeDetailsRepository.Get(x => x.EmployeeDetailId == EmployeeDetailId);
        //    var user = await _userManager.FindByEmailAsync(employee.Email);
        //    var employeeroles = await _userManager.GetRolesAsync(user);
        //    return employeeroles;
        //}
    }
}
