using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Persistance;

namespace OdeToFood.Pages.Resturants
{
    public class EditModel : PageModel
    {
        private readonly IResturantData resturantdata;
        private readonly IHtmlHelper htmlhelper;

        [BindProperty]
        public OdeToFood.Domain.Resturants ResturantDomain { get; set; }
        public IEnumerable<SelectListItem> CusinesList { get; set; }

        public EditModel(IResturantData resturantdata, IHtmlHelper htmlhelper)
        {
            this.resturantdata = resturantdata;
            this.htmlhelper = htmlhelper;
        }
        public IActionResult OnGet(int? resturantId)
        {
            if (resturantId.HasValue)
            {
                ResturantDomain = resturantdata.GetResturantByID(resturantId.Value);
            }
            else
            {
                ResturantDomain = new Domain.Resturants();
            }
            CusinesList = htmlhelper.GetEnumSelectList<OdeToFood.Domain.CusineType>();
            if (ResturantDomain is null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            CusinesList = htmlhelper.GetEnumSelectList<OdeToFood.Domain.CusineType>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ResturantDomain.Id > 0)
            {
                ResturantDomain = resturantdata.update(ResturantDomain);
            }
            else
            {
                resturantdata.Add(ResturantDomain);
            }

            resturantdata.Commit();
            TempData["Message"] = "Saved !";
            return RedirectToPage("./Detail", new { resturantId = ResturantDomain.Id });

        }

    }
}
