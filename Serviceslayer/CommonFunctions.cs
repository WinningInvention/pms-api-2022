using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serviceslayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer
{
    public static class CommonFunctions
    {
        private static readonly IConfiguration _config;
        
        public static string GetRandomPassword(int length)
        {
            const string specialCharacters = "!@#$%^*()_-=[]{}|',<>";
            byte[] rgb = new byte[length];
            RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider();
            while (true)
{
                rngCrypt.GetBytes(rgb);
                string password = Convert.ToBase64String(rgb);

                // Check if the password contains at least one number, one special character, and one capital letter
                if (password.Any(char.IsDigit) && password.Any(c => specialCharacters.Contains(c)) && password.Any(char.IsUpper))
                {
                    return password;
                }
            }
        }

        public static JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
