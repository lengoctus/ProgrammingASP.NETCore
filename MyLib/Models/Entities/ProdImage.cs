using System;
using System.Collections.Generic;

namespace MyLib.Models.Entities
{
    public partial class ProdImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProdId { get; set; }

        public virtual Product Prod { get; set; }
    }
}
