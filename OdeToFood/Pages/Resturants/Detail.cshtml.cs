using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Domain;
using OdeToFood.Persistance;

namespace OdeToFood.Pages.Resturants
{
    public class DetailModel : PageModel
    {
        private readonly IResturantData resturants;
        public OdeToFood.Domain.Resturants MyResturant { get; set; }

        public DetailModel(IResturantData resturants)
        {
            this.resturants = resturants;
        }
        public IActionResult OnGet(int resturantId)
        {

             MyResturant = resturants.GetResturantByID(resturantId);
           
            if (MyResturant is null) return RedirectToPage("./NotFound");
            else return Page();
            // MyResturant = new Domain.Resturants() { Id = resturantId };

        }
    }
}
