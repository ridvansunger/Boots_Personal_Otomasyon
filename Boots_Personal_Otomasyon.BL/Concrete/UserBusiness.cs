using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.BL.Concrete
{
    using Abstract;
    using Boots_Personal_Otomasyon.DTO;
    using DAL.Abstract;

    public class UserBusiness:IUserBusiness
    {

        private IUserRepository _userService;
        public UserBusiness(IUserRepository userService)
        {
            _userService = userService;
        }

        public UserDTO GetUser(string username, string password)
        {
            return _userService.GetUser(username, password);
        }
    }
}
