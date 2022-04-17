using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.WEBUI.Controllers
{

    using Models;
    using BL.Abstract;
    using AutoMapper;
    using Entities;

    public class PersonalController : Controller
    {
        private IPersonalBusiness _personelBusiness;
        private IMapper _mapper;

        public PersonalController(IPersonalBusiness personalBusiness, IMapper mapper)
        {
            _personelBusiness = personalBusiness;
            _mapper = mapper;
        }

        [HttpGet("personal-list")]
        public IActionResult PersonalList()
        {
            return View();
        }


        [HttpGet("personal/{id?}")]
        public async Task<IActionResult> PersonalDetail(int? id)
        {

            PersonalVM personalVM = null;
            if(id>0 && id!=null)
            {
                var personal = await _personelBusiness.GetById(Convert.ToInt32(id));
                if(personal !=null)
                personalVM = _mapper.Map<PersonalVM>(personal);
            }
            return View(personalVM);
        }


        //metotlar async task olduğu için actionresultları boyle yazdık
        //gelen personel automaapper ile entity ye dönüşüp db ye gitti.
        //sayfayı kaydettikten sonra get ile sql deki kaydedilmiş hail ile açıyoruz. id de görünüyor get olduğu için
        [HttpPost("personal/{id?}")]
        public async Task<IActionResult> PersonalDetail(int id,PersonalVM item)
        {
            //automapper ile vm i entitye dönüştürdük
            var personal = _mapper.Map<Personal>(item);
            if (personal.Id > 0)
            {
                //update işlemi

                await _personelBusiness.Update(personal);
            }
            else
            {
                //ınsert
                await _personelBusiness.Add(personal);
                //burada yönlendirme yaptık
                return Redirect("/personal/" + personal.Id.ToString());
            }
            return View();
        }



        [HttpGet("personal-datatable-list/{id?}")]
        public  IActionResult PersonalDataTableList()
        {
            return View();
        }
    }
}
