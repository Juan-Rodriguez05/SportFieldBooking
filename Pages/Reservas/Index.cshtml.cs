using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportFieldBooking.Pages.Reservas
{
    [Authorize]
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