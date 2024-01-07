using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_aplicatieWeb.Data;
using Proiect_aplicatieWeb.Models;

namespace Proiect_aplicatieWeb.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext _context;

        public IndexModel(Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Programare = await _context.Programare
                .Include(p => p.Interventie)
                .Include(p => p.Medic).ToListAsync();
        }
    }
}
