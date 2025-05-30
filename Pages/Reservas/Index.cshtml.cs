using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Models;
using SportFieldBooking.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportFieldBooking.Pages.Reservas
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;

        public IndexModel(SportContext context)
        {
            _context = context;
        }

        public IList<Reserva> Reservas { get; set; } = new List<Reserva>()!;

        public async Task OnGetAsync()
        {
            Reservas = await _context.Reservas
                .Include(r => r.Campo)
                .Include(r => r.Cliente)
                .ToListAsync();
        }
    }
}