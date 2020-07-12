using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MyLib.Library;
using MyLib.Models.ModelViews;
using MyLib.Repository.IRepository;
using Newtonsoft.Json.Linq;

namespace MyLib.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "1", AuthenticationSchemes = SchemaRole.ADMIN)]
    [Route("admin/account")]
    public class AdminAccountController : Controller
    {
        private readonly IAccountRepo _IAcc;
        private readonly IWebHostEnvironment IWebhost;

        public AdminAccountController(IAccountRepo iAcc, IWebHostEnvironment iWebhost)
        {
            _IAcc = iAcc;
            IWebhost = iWebhost;
        }

        [HttpGet("")]
        [HttpGet("index")]
        public IActionResult Index()
        {

            return View(_IAcc.GetAllEmployee());
        }

        [HttpGet("create")]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(AccountView accountView, IFormFile photo)
        {
            if (ModelState.IsValid && photo != null && photo.FileName.Length > 0)
            {
                var filename = SaveFile.SaveImage(photo, "Admin\\images\\Account", IWebhost).Result;
                if (filename == null) return View("0");

                accountView.Image = filename;

                var result = _IAcc.CreateAccount(accountView);
                if (result != null)
                {
                    ViewBag.photo = photo.FileName;
                    ViewBag.result = 1;
                }
                else
                {
                    SaveFile.Remove(filename, "Admin\\images\\Account", IWebhost);
                    ViewBag.result = 0;
                }
            }
            return View(accountView);
        }

        [HttpGet("edit")]
        public IActionResult Edit([FromQuery] int AccId)
        {
            var acc = _IAcc.GetAccount(AccId);
            if (acc != null)
            {
                return View(acc);
            }
            return RedirectToAction("index");
        }

        [HttpPost("edit")]
        public IActionResult Edit(AccountView acc, IFormFile photo)
        {
            var regEmail = new Regex(@"^[\w]+@{1}[a-z]{2,3}.[a-z]{2,3}$");
            var regFullName = new Regex(@"^[a-zA-Z\s]+$");


            if (regEmail.IsMatch(acc.Email) && regFullName.IsMatch(acc.FullName))
            {
                ViewBag.result = _IAcc.UpdateAccount(acc);
                return View(acc);
            }
            acc.Image = _IAcc.GetAccount(acc.Id).Image;
            ViewBag.result = false;

            return View(acc);
        }

        [HttpPost("removeAcc")]
        public IActionResult Remove([FromBody] int[] arr)
        {
            if (arr.Length > 0)
            {
                if (_IAcc.UpdateStatus(arr))
                {
                    return Json("1");
                }
            }
            return Json("0");
        }

        [HttpPost("updateActive")]
        public IActionResult UpdateActive([FromBody] Object info)
        {
            dynamic accView = JObject.Parse(info.ToString());
            var result = _IAcc.UpdateActive((int)accView.idAcc, (bool)accView.ischeck);
            return result ? Json("1") : Json("0");
        }
    }
}
