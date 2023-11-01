using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pms_core_api.Models;
using Serviceslayer;
using Serviceslayer.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSenderService _emailSenderService;

        public LoginController(IConfiguration config, IUserService userService, UserManager<ApplicationUser> userManager, IEmailSenderService emailSenderService)
        {
            _config = config;
            _userService = userService;
            _userManager = userManager;
            _emailSenderService = emailSenderService;   
        }
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("/api/login")]
        //public IActionResult Login()
        //{
        //    UserModel login = new UserModel()
        //    {
        //        EmailId = "Santanu@gamil.com",
        //        Password = "Sanu0509",
        //        UserName = "Sanu0509"

        //    };
        //    IActionResult response = Unauthorized();
        //    var user = AuthenticateUser(login);

        //    if (user != null)
        //    {
        //        var tokenString = GenerateJSONWebToken(user);
        //        response = Ok(new { token = tokenString });
        //    }

        //    return response;
        //}

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

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginModelDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    Status = "Error",
                    Message = "User with this email does not exists!"
                });

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = CommonFunctions.GetToken(authClaims);
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Success",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    userRoles = userRoles,
                    //refreshToken = refreshTokenId
                });
            }
            return StatusCode(StatusCodes.Status200OK, new Response
            {
                Status = "Error",
                Message = "Pasword is incorrect!"
            });
        }
        //private JwtSecurityToken GetToken(List<Claim> authClaims)
        //{
        //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

        //    var token = new JwtSecurityToken(
        //        issuer: _config["Jwt:Issuer"],
        //        audience: _config["Jwt:Issuer"],
        //        expires: DateTime.Now.AddMinutes(30),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //        );

        //    return token;
        //}

        [HttpPost(nameof(AddNewUser))]
        public async Task<IActionResult> AddNewUser(CreateUserDto createUserDto)
        {
            var userexists = await _userManager.FindByEmailAsync(createUserDto.Email);
            if (userexists != null)
                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    Status = "error",
                    Message = "user with this email already exists!"
                });

            ApplicationUser user = new()
            {
                Email = createUserDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = createUserDto.UserName,
                Gender = createUserDto.Gender,
                NadicsNumber=createUserDto.NadicsNumber,
                Position=createUserDto.Position
              
            };

            int length = 10;
            string password = CommonFunctions.GetRandomPassword(length);
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status200OK, new Response
                {
                    Status = "error",
                    Message = "user creation failed!" + string.Join(",", result.Errors.Select(x => x.Description).ToList())
                });
            _emailSenderService.SendTemporaryPassword(createUserDto.UserName, password, createUserDto.Email);
            return Ok(new Response { Status = "success", Message = "user created successfully!" });
        }
        //private static string GetRandomPassword(int length)
        //{
        //    const string specialCharacters = "!@#$%^*()_-=[]{}|',<>";
        //    byte[] rgb = new byte[length];
        //    RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider();
        //    while (true)
        //    {
        //        rngCrypt.GetBytes(rgb);
        //        string password = Convert.ToBase64String(rgb);

        //        // Check if the password contains at least one number, one special character, and one capital letter
        //        if (password.Any(char.IsDigit) && password.Any(c => specialCharacters.Contains(c)) && password.Any(char.IsUpper))
        //        {
        //            return password;
        //        }
        //    }
        //}
    }
}