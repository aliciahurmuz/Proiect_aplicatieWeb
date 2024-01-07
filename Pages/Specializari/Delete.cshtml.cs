using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_aplicatieWeb.Data;
using Proiect_aplicatieWeb.Models;

namespace Proiect_aplicatieWeb.Pages.Specializari
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext _context;

        public DeleteModel(Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Specializare Specializare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specializare = await _context.Specializare.FirstOrDefaultAsync(m => m.Id == id);

            if (specializare == null)
            {
                return NotFound();
            }
            else
            {
                Specializare = specializare;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specializare = await _context.Specializare.FindAsync(id);
            if (specializare != null)
            {
                Specializare = specializare;
                _context.Specializare.Remove(Specializare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
