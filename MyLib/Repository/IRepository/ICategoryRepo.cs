using MyLib.Models.Entities;
using MyLib.Models.ModelViews;
using MyLib.Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Repository.IRepository
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        List<CategoryView> GetAllCategory_Customer();
    }
}
