using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportFieldBooking.Data;
using SportFieldBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace SportFieldBooking.Pages.Eventos
{
    public class EditModel : PageModel
    {
        private readonly SportContext _context;

        public EditModel(SportContext context)
        {
            _context = context;
        }

        [BindProperty]

        public Evento Evento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }
            var evento = await _context.Eventos.FirstOrDefaultAsync(m => m.IdEvento == id);

            if (evento == null)
            {
                return NotFound();
            }
            Evento = evento;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(Evento.IdEvento))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }
        private bool EventoExists(int id)
        {
            return (_context.Eventos?.Any(e => e.IdEvento == id)).GetValueOrDefault();
        }
    }
}
