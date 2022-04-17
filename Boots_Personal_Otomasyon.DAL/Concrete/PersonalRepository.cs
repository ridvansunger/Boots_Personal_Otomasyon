using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Concrete
{
    using Abstract;
    using Boots_Personal_Otomasyon.DAL.Context.EF;
    using Boots_Personal_Otomasyon.Entities;
    

    public class PersonalRepository : GenericRepository<Personal>, IPersonalRepository
    {

        // PersonalREpository kızartığı için ctrl nokta deyip genreate personalcontext i ctory aldık,basede ctor olmadığı iiçn boyle yaptık
        public PersonalRepository(PersonalContext Db) : base(Db)
        {

        }
    }
}
