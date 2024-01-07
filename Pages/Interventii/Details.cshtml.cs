using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_aplicatieWeb.Data;
using Proiect_aplicatieWeb.Models;

namespace Proiect_aplicatieWeb.Pages.Interventii
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext _context;

        public DetailsModel(Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext context)
        {
            _context = context;
        }

        public Interventie Interventie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interventie = await _context.Interventie.FirstOrDefaultAsync(m => m.Id == id);
            if (interventie == null)
            {
                return NotFound();
            }
            else
            {
                Interventie = interventie;
            }
            return Page();
        }
    }
}
