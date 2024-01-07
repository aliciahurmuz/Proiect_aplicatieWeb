using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_aplicatieWeb.Data;
using Proiect_aplicatieWeb.Models;

namespace Proiect_aplicatieWeb.Pages.Medici
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext _context;

        public DeleteModel(Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medic Medic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medic = await _context.Medic.FirstOrDefaultAsync(m => m.Id == id);

            if (medic == null)
            {
                return NotFound();
            }
            else
            {
                Medic = medic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medic = await _context.Medic.FindAsync(id);
            if (medic != null)
            {
                Medic = medic;
                _context.Medic.Remove(Medic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
