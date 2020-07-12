using Microsoft.AspNetCore.Mvc;
using MyLib.Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Models.Entities
{
    public class CategoryPartial
    {

    }

    [ModelMetadataType(typeof(CategoryPartial))]
    public partial class Category : IEntity
    {

    }
}
