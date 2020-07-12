using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyLib.Models.Entities;
using MyLib.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Library
{

    public class AuthenticateModel
    {
        public static string GenerateJWTToken(AppSettings _appSettings, AccountView account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.SeCret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim("Id", account.Id.ToString()),
                    new Claim("Role", account.Role.ToString()),
                    new Claim(ClaimTypes.Name, account.FullName)
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }

    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class AppSettings
    {
        public string SeCret { get; set; }
    }

    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(AccountView accountView, string token)
        {
            Id = accountView.Id;
            Name = accountView.FullName;
            Email = accountView.Email;
            Role = accountView.Role;
            Token = token;
        }
    }
}
