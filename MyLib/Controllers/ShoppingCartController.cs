using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyLib.Controllers
{
    [Route("shoppingCart")]
    public class ShoppingCartController : Controller
    {
        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
