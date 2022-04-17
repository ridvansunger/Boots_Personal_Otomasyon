using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.BL.Abstract
{
    using Entities;
    public interface IPersonalBusiness
    {
        IQueryable<Personal> GetAll(Func<Personal, bool> predicate=null);
        Task<Personal> GetById(int id);
        Task Add(Personal entity);
        Task Update(Personal entity);
        Task Delete(int id);
    }

}
