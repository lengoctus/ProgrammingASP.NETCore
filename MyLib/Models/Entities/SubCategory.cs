using System;
using System.Collections.Generic;

namespace MyLib.Models.Entities
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool? Active { get; set; }
        public bool? Status { get; set; }
        public int CateId { get; set; }

        public virtual Category Cate { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
