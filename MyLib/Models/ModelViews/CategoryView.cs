using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Models.ModelViews
{
    public class CategoryView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool? Active { get; set; }
        public bool? Status { get; set; }
        public string Image { get; set; }

        public List<SubCategoryView> SubCategoryView { get; set; }
    }
}
