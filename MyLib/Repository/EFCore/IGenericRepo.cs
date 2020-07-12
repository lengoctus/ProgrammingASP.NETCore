using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Repository.EFCore
{
    public interface IGenericRepo<T> where T : class
    {
        IQueryable<T> GetAllNTU();

        Task<T> CreateNTU(T entity);

        Task<bool> UpdateNTU(T entity);
        Task<bool> UpdateMultiFieldNTU(List<T> listEntity);

        Task<bool> RemoveNTU(int[] Id);
        Task<T> GetByIdNTU(int Id);
    }
}
