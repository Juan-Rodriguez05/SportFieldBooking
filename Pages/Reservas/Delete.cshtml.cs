using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Reservas
{
    public class DeleteModel : PageModel
    {
        private readonly SportContext _context;

        public DeleteModel(SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Reserva = await _context.Reservas
                .Include(r => r.Campo)
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.IdReserva == id);

            if (Reserva == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Reserva = await _context.Reservas.FindAsync(id);

            if (Reserva != null)
            {
                _context.Reservas.Remove(Reserva);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}