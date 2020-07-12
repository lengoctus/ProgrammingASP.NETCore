using Microsoft.AspNetCore.Mvc;
using MyLib.Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Models.Entities
{
    public class SubCategoryPartial
    {
    }

    [ModelMetadataType(typeof(SubCategoryPartial))]
    public partial class SubCategory : IEntity
    {
    }
}
