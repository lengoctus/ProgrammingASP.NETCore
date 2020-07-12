using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using MyLib.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Repository.EFCore
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class, IEntity
    {
        private readonly ConnectDbContext _db;

        public GenericRepo(ConnectDbContext db)
        {
            _db = db;
        }


        //========================================================    CREATE  ==============================================
        #region
        public async Task<T> CreateNTU(T entity)
        {
            try
            {
                await _db.Set<T>().AddAsync(entity);
                await _db.SaveChangesAsync();

                return await Task.FromResult(entity);
            }
            catch (Exception e)
            {

                return await Task.FromResult<T>(null);
            }
        }
        #endregion


        //========================================================    GET ALL ============================================
        #region
        public IQueryable<T> GetAllNTU()
        {
            try
            {
                return _db.Set<T>().AsNoTracking();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion


        //=========================================================   Remove  ================================================
        #region
        public async Task<bool> RemoveNTU(int[] Id)
        {
            try
            {
                var listEntity = _db.Set<T>().Where(p => Id.Contains(p.Id));

                if (listEntity.Count() > 0)
                {
                    _db.Set<T>().RemoveRange(listEntity);
                    await _db.SaveChangesAsync();
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        #endregion


        //=========================================================   Update  ================================================
        #region
        public async Task<bool> UpdateNTU(T entity)
        {
            try
            {
                var ent = _db.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == entity.Id);
                if (ent != null)
                {
                    _db.Set<T>().Update(entity);
                    await _db.SaveChangesAsync();
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateMultiFieldNTU(List<T> listEntity)
        {
            try
            {
                var listent = _db.Set<T>().AsNoTracking().Where(p => listEntity.Contains(p));
                if (listent != null && listent.Count() == listEntity.Count)
                {
                    _db.Set<T>().UpdateRange(listEntity);
                    await _db.SaveChangesAsync();
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }
        #endregion


        //=========================================================   Get By Id  ================================================
        #region
        public async Task<T> GetByIdNTU(int Id) {
            try
            {
                var entity = _db.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == Id);
                return await Task.FromResult(entity);
            }
            catch (Exception e)
            {
                return await Task.FromResult<T>(null);
            }
        }
        #endregion
    }
}
