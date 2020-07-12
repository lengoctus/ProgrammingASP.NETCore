using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Models.ModelViews
{
    public class ProductView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool? Active { get; set; }
        public bool? Status { get; set; }
        public int SubCateId { get; set; }

        public List<ProdImageView> ProdImageViews { get; set; }
    }
}
