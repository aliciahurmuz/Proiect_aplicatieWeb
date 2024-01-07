using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Proiect_aplicatieWeb.Models;

namespace Proiect_aplicatieWeb.Pages.Programari
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
            // Alte inițializări
            ViewData["InterventieId"] = new SelectList(_context.Interventie, "Id", "Denumire");
            ViewData["MedicId"] = new SelectList(_context.Medic.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = $"{m.Nume} {m.Prenume}"
            }), "Value", "Text");

            // Inițializare pentru Pacienti
            ViewData["Pacienti"] = new SelectList(_context.Pacient.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.Nume} {p.Prenume}"
            }), "Value", "Text");

            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validare și preluare manuală a datelor pentru PacientId
            var pacientIdString = Request.Form["Programare.PacientId"];
            if (!string.IsNullOrEmpty(pacientIdString) && int.TryParse(pacientIdString, out var pacientId))
            {
                Programare.PacientId = pacientId;
            }
            else
            {
                ModelState.AddModelError(nameof(Programare.PacientId), "Please select a valid Pacient");
            }
            ModelState.Remove("Programare.Pacient");

            // Validare și preluare manuală a datelor pentru IdMedic
            var medicIdString = Request.Form["Programare.MedicId"];
            if (!string.IsNullOrEmpty(medicIdString) && int.TryParse(medicIdString, out var medicId))
            {
                Programare.MedicId = medicId;
            }
            else
            {
                ModelState.AddModelError(nameof(Programare.MedicId), "Please select a valid Medic");
            }
            ModelState.Remove("Programare.Medic");

            // Validare și preluare manuală a datelor pentru IdInterventie
            var interventieIdString = Request.Form["Programare.InterventieId"];
            if (!string.IsNullOrEmpty(interventieIdString) && int.TryParse(interventieIdString, out var interventieId))
            {
                Programare.InterventieId = interventieId;
            }
            else
            {
                ModelState.AddModelError(nameof(Programare.InterventieId), "Please select a valid Interventie");
            }
            ModelState.Remove("Programare.Interventie");

            // Verificare dacă ModelState este validă după validarea manuală
            if (!ModelState.IsValid)
            {
                // Întoarceți pagina cu erorile de validare
                return Page();
            }

            // Adăugați Programare în context și salvați în baza de date
            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            // Aici trebuie să adăugați o redirecționare către Index
            return RedirectToPage("./Index");
        }


    }
}
