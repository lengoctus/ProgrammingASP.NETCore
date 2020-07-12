using System;
using System.Collections.Generic;

namespace MyLib.Models.Entities
{
    public partial class Category
    {
        public Category()
        {
            SubCategory = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool? Active { get; set; }
        public bool? Status { get; set; }
        public string Image { get; set; }

        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
