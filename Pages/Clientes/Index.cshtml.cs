using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportFieldBooking.Pages.Clientes
{
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
