using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Abstract
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll(Func<T,bool> predicate);
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
