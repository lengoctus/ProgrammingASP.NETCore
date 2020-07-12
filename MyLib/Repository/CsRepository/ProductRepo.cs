using MyLib.Models.Entities;
using MyLib.Models.ModelViews;
using MyLib.Repository.EFCore;
using MyLib.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Repository.CsRepository
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        public ProductRepo(ConnectDbContext db) : base(db)
        {
        }




        //=====================================   CUSTOMER    ===================================
        public List<ProductView> GetAllProducts_Customer()
        {
            var d =  GetAllNTU().Where(p => p.Status == true && p.Active == true).Select(p => new ProductView
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                Active = p.Active,
                SubCateId = p.SubCateId,
                Code = p.Code,
                ProdImageViews = p.ProdImage.Select(l => new ProdImageView
                {
                    Id = l.Id,
                    Name = l.Name,
                    ProdId = l.ProdId
                }).ToList()
            }).ToList();

            return d;
        }
    }
}
