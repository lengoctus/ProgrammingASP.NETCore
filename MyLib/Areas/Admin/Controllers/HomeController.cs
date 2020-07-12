using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLib.Library;

namespace MyLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "1", AuthenticationSchemes = SchemaRole.ADMIN)]
    [Route("admin/home")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
