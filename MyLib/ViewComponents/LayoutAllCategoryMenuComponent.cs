using Microsoft.AspNetCore.Mvc;
using MyLib.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.ViewComponents
{
    [ViewComponent(Name = "LayoutAllCategoryMenu")]
    public class LayoutAllCategoryMenuComponent : ViewComponent
    {
        private readonly ICategoryRepo _ICate;

        public LayoutAllCategoryMenuComponent(ICategoryRepo iCate)
        {
            _ICate = iCate;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listCate = _ICate.GetAllCategory_Customer();
            return View("Index", listCate);
        }
    }
}
