using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.WEBUI.Controllers
{
    using BL.Abstract;
    using DTO;
    using Models;
    public class AccountController : Controller
    {
        private IUserBusiness _userService;
        public AccountController(IUserBusiness userBusiness)
        {
            _userService = userBusiness;
        }

        //[Route("login")]
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        //route attleri iptal ettik.
        //[Route("login")]
        [HttpPost("login")]
        public IActionResult Login(UserVM user)
        {

            //buları oluşturduktan sonra loginde formun classlarını tanımladık
            //< form asp - action = "/Login" method = "post" >

            var dbUSer = _userService.GetUser(user.UserName, user.Password);
            if (dbUSer != null)
            {
                //redirecttoAction ı redirect yaptık controller istiyor.
                return Redirect("home");
            }
            else
            {
                return View(user);
            }
            //post olduğunda home git

        }


        [Route("logout")]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
