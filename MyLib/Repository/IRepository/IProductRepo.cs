using MyLib.Models.Entities;
using MyLib.Models.ModelViews;
using MyLib.Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Repository.IRepository
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        List<ProductView> GetAllProducts_Customer();
    }
}
