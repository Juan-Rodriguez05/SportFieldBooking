using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Eventos
{
    public class CreateModel : PageModel
    {
        private readonly SportContext _context;

        public CreateModel(SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evento Evento { get; set; } = null!;

        public SelectList Campos { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync()
        {
            var campos = await _context.Campos
                .OrderBy(c => c.Nombre)
                .ToListAsync();

            Campos = new SelectList(campos, "IdCampo", "Nombre");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var campos = await _context.Campos.ToListAsync();
                Campos = new SelectList(campos, "IdCampo", "Nombre");
                return Page();
            }

            _context.Eventos.Add(Evento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}