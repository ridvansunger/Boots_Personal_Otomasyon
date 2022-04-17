using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCGrid.NetCore;

namespace Boots_Personal_Otomasyon.WEBUI
{
   
    using DAL.Context.EF;
    using Microsoft.EntityFrameworkCore;
    //buraya hem BL hemde DAL katmanlar� ekledik
    using DAL.Abstract;
    using DAL.Concrete;
    using BL.Abstract;
    using BL.Concrete;
    using AutoMapperConfig;
    using AutoMapper;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //vm modeli entity i�in automap de buraya ekledik.
            //services.AddAutoMapper(cfg=>cfg.AddProfile<GeneralProfile>(),typeof(Startup));
            var mapperConfig = new MapperConfiguration(mc => mc.AddProfile<GeneralProfile>());
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);



            services.AddControllersWithViews();
            //Ef context ekledik.
            services.AddDbContext<PersonalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PersonalCs")));


            //mvcGrid i�in ekldndi.
            services.AddMvcGrid();

            //kullan�lacak servieleri buraya ekliyoruz.
            //Singleton => uygulama i�eriidne ba��ml�l�k olu�turuan nesneler i�in tek bir sefer olu�turr ve istenildi�inde ayn� nesneyi d�ner.
            //skoped => uygulama i�erisindeki ba��ml�l�k olu�turan nesnenin request sonlanana kadar ayn� nesneyi d�ner.
            //Transient => uygulama i�erisidne ba��ml�l�k olu�turan nesnenin her seferinde ayr� bir instance d�ner.
            //IUSerRepository istedi�imizde USerReposirory yi verecek singleton olarak
            services.AddScoped<IUserRepository, UserRepository>();
            //IUserBusiness istedi�imde UserBusiness e ver
            services.AddScoped<IUserBusiness, UserBusiness>();


            services.AddScoped<IPersonalRepository, PersonalRepository>();
            services.AddScoped<IPersonalBusiness, PersonalBusiness>();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IPersonalBusiness personalBusiness, IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();



            //grid i�in yatpt�k datatable grid kullanmak i�in yazd�k
            //parametre olarak personelbusiness g�nderdik
            app.RegisterMVCGrid("PersonalListGrid", Grid.PersonalListGrid.PersonalListGridCustomize(app));
            app.UseMvcGrid();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
