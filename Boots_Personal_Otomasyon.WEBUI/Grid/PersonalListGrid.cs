using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.WEBUI.Grid
{
    using Models;
    using MVCGrid.Models;
    using BL.Abstract;
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class PersonalListGrid
    {

        
        public static MVCGridBuilder<PersonalVM> PersonalListGridCustomize(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var personalBusiness = scope.ServiceProvider.GetService<IPersonalBusiness>();
            var mapper = scope.ServiceProvider.GetService<IMapper>();


            ColumnDefaults columnDefaults = new ColumnDefaults()
            {
                EnableSorting = true
            };


            return new MVCGridBuilder<PersonalVM>(columnDefaults).WithAuthorizationType(AuthorizationType.AllowAnonymous).WithSorting(sorting: true, defaultSortColumn: "Id", defaultSortDirection: SortDirection.Dsc).WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100).AddColumns(
                cols =>
                {
                    cols.Add("Id").WithValueExpression(t => t.Id.ToString()).WithAllowChangeVisibility(true);
                    cols.Add("NameANdSurname").WithHeaderText("Adı Soyadı").WithVisibility(true, true).WithValueExpression(t => t.NameANdSurname);
                    cols.Add("Email").WithHeaderText("Email").WithVisibility(true, true).WithValueExpression(t => t.Email);
                    cols.Add("Phone").WithHeaderText("Telefon").WithVisibility(true, true).WithValueExpression(t => t.Phone);
                    cols.Add("BirthDate").WithHeaderText("Doğum Tarihi").WithVisibility(true, true).WithValueExpression(t => t.BirthDate?.ToString("dd.MM.yyyy"));
                    cols.Add("IdentifierNumber").WithHeaderText("TC Kimlik No").WithVisibility(true, true).WithValueExpression(t => t.IdentifierNumber);
                    //cols.Add().WithColumnName("Url").WithValueExpression((i,c)=>c.Helper)
                }
                ).WithRetrieveDataMethod((context) =>
                {

                    QueryOptions options = context.QueryOptions;
                    int pageIndex = options.PageIndex.Value;
                    int pageSize = options.ItemsPerPage.Value;
                    options.GetFilterString("Phone");
                    //int totalCount = 120;


                    //GEneric repodaki get metodunu değiştiriik.
                    List<PersonalVM> list = new List<PersonalVM>();
                    var result= personalBusiness.GetAll().Skip(pageIndex).Take(pageSize).ToList();
                    
                    if(result.Count>0)
                    {
                        foreach (var item in result)
                        {
                            list.Add(mapper.Map<PersonalVM>(item));
                        }

                        return new QueryResult<PersonalVM>() { Items = list, TotalRecords = result.Count };
                    }
               

                    //List<PersonalVM> list = new List<PersonalVM>()
                    //{
                    //    new PersonalVM{Id=1,NameANdSurname="Emre Özbaşkan"},
                    //    new PersonalVM{Id=2,NameANdSurname="Rıdvan Sünger"},
                    //};

                    return new QueryResult<PersonalVM>() { Items = list, TotalRecords = list.Count };
                });


        }


    }
}
