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
    public class IndexModel : PageModel
    {
        private readonly Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext _context;

        public IndexModel(Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext context)
        {
            _context = context;
        }

        public IList<Interventie> Interventie { get;set; } = default!;
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(string searchString)
        {
            IQueryable<Interventie> interventiiQuery = _context.Interventie.Include(i => i.Specializare);

            if (!String.IsNullOrEmpty(searchString))
            {
                interventiiQuery = interventiiQuery.Where(i => i.Denumire.Contains(searchString)
                                                  || i.Specializare.Denumire.Contains(searchString));
            }

            Interventie = await interventiiQuery.ToListAsync();
            CurrentFilter = searchString;
        }


    }
}
