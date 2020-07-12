using Microsoft.EntityFrameworkCore;
using MyLib.Models.Entities;
using MyLib.Models.ModelViews;
using MyLib.Repository.EFCore;
using MyLib.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MyLib.Repository.CsRepository
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(ConnectDbContext db) : base(db)
        {
        }









        //===============================================     CUSTOMER    ============================
        public List<CategoryView> GetAllCategory_Customer()
        {
            return GetAllNTU().Where(p => p.Status == true && p.Active == true).Include(p => p.SubCategory).Select(p => new CategoryView
            {
                Id = p.Id,
                Name = p.Name,
                Quantity = p.Quantity,
                Active = p.Active,
                Status = p.Status,
                Code = p.Code,
                Image = p.Image,
                SubCategoryView = p.SubCategory.Select(p => new SubCategoryView
                {
                    Id = p.Id,
                    Name = p.Name,
                    Quantity = p.Quantity,
                    Active = p.Active,
                    Status = p.Status,
                    CateId = p.CateId,
                    Code = p.Code
                }).ToList()
            }).ToList(); ;
        }
    }
}
