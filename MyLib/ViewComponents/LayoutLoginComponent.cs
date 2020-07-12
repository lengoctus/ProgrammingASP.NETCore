﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.ViewComponents
{
    [ViewComponent(Name = "LayoutLogin")]
    public class LayoutLoginComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() {

            return View("index");
        }
    }
}
