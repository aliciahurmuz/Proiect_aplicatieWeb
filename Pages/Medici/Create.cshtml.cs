using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_aplicatieWeb.Data;
using Proiect_aplicatieWeb.Models;

namespace Proiect_aplicatieWeb.Pages.Medici
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext _context;

        public CreateModel(Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SpecializareId"] = new SelectList(_context.Specializare, "Id", "Denumire");
            return Page();
        }

        [BindProperty]
        public Medic Medic { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            Medic.SpecializareId = int.Parse(Request.Form["Medic.SpecializareId"]);

            if (Medic.SpecializareId <= 0)
            {
                ModelState.AddModelError(nameof(Medic.SpecializareId), "Please select a valid Specializare");
            }

            ModelState.Remove("Medic.Specializare");


            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.Medic.Add(Medic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
