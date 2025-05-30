using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Campos
{
    [Authorize(Roles = "Administrador")]
    public class DeleteModel : PageModel
    {
        private readonly SportContext _context;

        public DeleteModel(SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Campo Campo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Campos == null)
            {
                return NotFound();
            }

            var campo = await _context.Campos.FirstOrDefaultAsync(m => m.IdCampo == id);

            if (campo == null)
            {
                return NotFound();
            }
            else
            {
                Campo = campo;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Campos == null)
            {
                return NotFound();
            }

            var campo = await _context.Campos.FindAsync(id);

            if (campo != null)
            {
                Campo = campo;
                _context.Campos.Remove(Campo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
