using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serviceslayer;
using Serviceslayer.Interfaces;
using System.Data;

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : Controller
    {
        private readonly IUserRolesService _userRolesService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
      
        public UserRolesController(IUserRolesService userRolesService,RoleManager<IdentityRole> roleManager,
                UserManager<ApplicationUser> userManager)
        {
            _userRolesService = userRolesService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //[Authorize(Roles = UserRoles.Admin)]
        [HttpPost(nameof(AddEmployeeRoles))]
        public async Task<IActionResult> AddEmployeeRoles(string Email, string RoleNmae)
        {
            await _userRolesService.AddEmployeeRoles(Email, RoleNmae);
            return Ok("Roles Added Successfully");
        }

        //[Authorize(Roles = UserRoles.Admin)]
        [HttpGet(nameof(GetRoles))]
        public List<IdentityRole> GetRoles()
        {
            return _roleManager.Roles.ToList();
        }
    }
}
