using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.WEBUI.AutoMapperConfig
{
    using Entities;
    using Models;
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<PersonalVM, Personal>();
            CreateMap<Personal, PersonalVM>();
        }
    }
}
