using System;
using System.Collections.Generic;

namespace MyLib.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProdImage = new HashSet<ProdImage>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool? Active { get; set; }
        public bool? Status { get; set; }
        public int SubCateId { get; set; }

        public virtual SubCategory SubCate { get; set; }
        public virtual ICollection<ProdImage> ProdImage { get; set; }
    }
}
