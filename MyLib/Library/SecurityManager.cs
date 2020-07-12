using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyLib.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyLib.Library
{
    public  sealed class SecurityManager
    {
        public async void SignIn(HttpContext httpContext, Account account, string Schema)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(GetUserClaims(account), Schema);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await httpContext.SignInAsync(Schema, claimsPrincipal);
        }

        public async void SignOut(HttpContext httpContext, string Schema)
        {
            await httpContext.SignOutAsync(Schema);
        }

        private IEnumerable<Claim> GetUserClaims(Account account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Id", account.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, account.Email));
            claims.Add(new Claim(ClaimTypes.Name, account.FullName));
            claims.Add(new Claim(ClaimTypes.Role, account.Role.ToString()));
            return claims;
        }
    }

    public static class SchemaRole
    {
        public const string ADMIN = "SCHEMA_ADMIN";
        public const string EMP = "SCHEMA_EMP";
    }
}
