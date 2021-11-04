using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Domain;
using OdeToFood.Persistance;

namespace OdeToFood.Pages.Resturants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IResturantData resturants;

        public string Message { set; get; }
        public IEnumerable<OdeToFood.Domain.Resturants> ResturantsList { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTxt { get; set; }

        /// <summary>
        /// constructor for page model
        /// </summary>
        public ListModel(IConfiguration config, IResturantData resturants)
        {
            this.config = config;
            this.resturants = resturants;
        }
        public void OnGet()
        {
            Message =config["SettingsMessage"];
            ResturantsList = resturants.GetAllResturants();

        }
        
        public void GetByName()
        {
            ResturantsList = resturants.GetResturantByName(SearchTxt);
        }


    }
}
