using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLib.Library;
using MyLib.Models.Entities;
using MyLib.Models.ModelViews;
using MyLib.Repository.IRepository;

namespace MyLib.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {

        private readonly IAccountRepo _IAcc;

        public AccountController(IAccountRepo iAcc)
        {
            _IAcc = iAcc;
        }

        [HttpGet("")]
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(AccountView customerAcc)
        {
            if (customerAcc != null && customerAcc.Email.Length > 0 && customerAcc.Password.Length > 0)
            {
                var customer = _IAcc.LoginAccount_CUSTOMER(customerAcc);
                if (customer != null)
                {
                    new SecurityManager().SignIn(HttpContext, new Account { Id = customer.Id, FullName = customer.FullName, Email = customer.Email, Role = customer.Role }, SchemaRole.ADMIN);
                    return RedirectToAction("index", "home");
                }
            }
            return View();
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(AccountView accountView, IFormFile cusPhoto)
        {
            if (cusPhoto != null && cusPhoto.FileName.Length > 0)
            {

            }
            return View();
        }
    }
}
