using Microsoft.AspNetCore.Mvc;
using MyLib.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.ViewComponents
{
    [ViewComponent(Name = "SliderCategory")]
    public class SliderCategoryComponent : ViewComponent
    {

        private readonly ICategoryRepo _ICate;

        public SliderCategoryComponent(ICategoryRepo iCate)
        {
            _ICate = iCate;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listCate = _ICate.GetAllCategory_Customer();
            return View("default", listCate);
        }
    }


}
