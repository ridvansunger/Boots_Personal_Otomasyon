using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Concrete
{
    using Abstract;
    using Boots_Personal_Otomasyon.DAL.Context.EF;

    public abstract class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private PersonalContext _Db;

        public GenericRepository(PersonalContext Db)
        {
            _Db = Db;
        }

        public virtual async Task Add(T entity)
        {
            await _Db.Set<T>().AddAsync(entity);
            await _Db.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            var entity = await GetById(id);
            _Db.Set<T>().Remove(entity);
            await _Db.SaveChangesAsync();
        }


        public virtual IQueryable<T> GetAll(Func<T, bool> predicate=null)
        {
            
            var dbSet = _Db.Set<T>().AsQueryable();
           
            if(predicate !=null)
            {
                dbSet = dbSet.Where(predicate).AsQueryable();
            }

            return dbSet;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _Db.Set<T>().FindAsync(id);
            
        }

        public virtual async Task Update(T entity)
        {
            _Db.Set<T>().Update(entity);
            await _Db.SaveChangesAsync();
        }
    }
}
