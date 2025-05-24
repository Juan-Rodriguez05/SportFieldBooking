using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Pagos
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;

        public IndexModel(SportContext context)
        {
            _context = context;
        }

        public IList<Pago> Pagos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pagos != null)
            {
                Pagos = await _context.Pagos
                    .Include(p => p.Reserva)
                    .ToListAsync();
            }
        }
    }
}
