using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Concrete
{
    using Abstract;
    using Boots_Personal_Otomasyon.DTO;
    using Context.EF;

    public class UserRepository : IUserRepository
    {
        private PersonalContext _context;
        public UserRepository(PersonalContext context)
        {
            _context = context;
        }


        public UserDTO GetUser(string username, string password)
        {
            //return _context.UserAccounts.Where(t0 => t0.UserName == username && t0.Password == password).Select(t1 => new UserDTO { FullName = t1.FullName, UserAccountId = t1.UserAccountId }).FirstOrDefault();

            return (from t0 in _context.UserAccounts
                    where t0.UserName == username && t0.Password == password
                    select new UserDTO
                    {
                        FullName = t0.FullName,
                        UserAccountId = t0.Id,
                        UserName = t0.UserName

                    }).FirstOrDefault();
        }
    }
}
