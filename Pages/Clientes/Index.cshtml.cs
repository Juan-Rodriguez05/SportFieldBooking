using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Clientes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;
        public IndexModel(SportContext context)
        {
            _context = context;
        }
        public IList<Cliente> Clientes { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Clientes != null)
            {
                Clientes = await _context.Clientes.ToListAsync();
            }
        }
       
    }
}//Prueba1
