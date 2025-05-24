using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportFieldBooking.Data;
using SportFieldBooking.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SportFieldBooking.Pages.Eventos
{
    public class DeleteModel : PageModel
    {
        private readonly SportContext _context;
        public DeleteModel(SportContext context)
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

            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
            {
                Evento = evento;
                _context.Eventos.Remove(Evento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");   

        }
    }
}
