using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_aplicatieWeb.Models;

namespace Proiect_aplicatieWeb.Pages.Specializari
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext _context;

        public IndexModel(Proiect_aplicatieWeb.Data.Proiect_aplicatieWebContext context)
        {
            _context = context;
        }

        public IList<Specializare> Specializare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Specializare = await _context.Specializare.ToListAsync();
        }
    }
}
