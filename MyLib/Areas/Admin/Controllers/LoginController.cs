using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyLib.Library;
using MyLib.Models.ModelViews;
using MyLib.Repository.IRepository;

namespace MyLib.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Login")]
    public class LoginController : Controller
    {
        private readonly IAccountRepo _IAcc;
        private readonly AppSettings _appSettings;

        public LoginController(IOptions<AppSettings> appSettings, IAccountRepo iAcc)
        {
            _IAcc = iAcc;
            _appSettings = appSettings.Value;
        }

        [HttpGet("")]
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(AccountView account)
        {
            var rs = _IAcc.Login(account);
            if (rs == null) return View();

            new SecurityManager().SignIn(HttpContext, rs, SchemaRole.ADMIN);

            return RedirectToAction("index", "home");
        }


        [HttpGet("accessdenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            new SecurityManager().SignOut(HttpContext, SchemaRole.ADMIN);
            return View("login");
        }
    }
}
