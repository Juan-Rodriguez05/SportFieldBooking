using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportFieldBooking.Pages.Eventos
{
    public class IndexModel : PageModel
    {
       private readonly SportContext _context;
        public IndexModel(SportContext context)
        {
            _context = context;
        }
        public IList<Evento> Eventos { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Eventos != null)
            {
                Eventos = await _context.Eventos
                    .Include(e => e.Campo)
                    .ToListAsync();
            }
        }
    }
}
