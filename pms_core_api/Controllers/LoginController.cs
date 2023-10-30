using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pms_core_api.Models;
using Serviceslayer.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace pms_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("PMSPolicy")]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private readonly IUserService _userService;

        public LoginController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("/api/login")]
        public IActionResult Login()
        {
            UserModel login = new UserModel()
            {
                EmailId = "Santanu@gamil.com",
                Password = "Sanu0509",
                UserName = "Sanu0509"

            };
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            //var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("santanu@sanu@0509243d"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailId),
                new Claim("Password", userInfo.Password),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            var test = new JwtSecurityTokenHandler().WriteToken(token);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            //Validate the User Credentials 
            UserModel loginuser = new UserModel
            {
                UserName = login.UserName,
                Password = login.Password,
                EmailId = login.EmailId
            };
            return loginuser;
        }
        [HttpPost(nameof(SigneUpPullData))]
        public IActionResult SigneUpPullData([FromBody] User UserData)
        {

            var passwordencoding = System.Text.Encoding.UTF8.GetBytes(UserData.Password);
            UserData.Password = System.Convert.ToBase64String(passwordencoding);
            //var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            //    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            _userService.InsertUser(UserData);
            return Ok("Data inserted");


        }
    }
}