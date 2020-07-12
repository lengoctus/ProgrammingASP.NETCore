using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLib.Repository.IRepository;

namespace MyLib.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly IProductRepo _IProd;

        public HomeController(IProductRepo iProd)
        {
            _IProd = iProd;
        }


        [HttpGet("~/")]
        [HttpGet("index")]
        public IActionResult Index()
        {
            var listProd = _IProd.GetAllProducts_Customer();
            return View(listProd);
        }




    }
}
