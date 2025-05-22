using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Campos
{
    public class EditModel : PageModel
    {
        private readonly SportContext _context;

        public EditModel(SportContext context)
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

            Campo = campo;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Nos aseguramos de que el IdCampo sea válido
            var existingCampo = await _context.Campos.FindAsync(Campo.IdCampo);
            if (existingCampo == null)
            {
                return NotFound();
            }

            // Actualiza solo las propiedades editables
            existingCampo.Nombre = Campo.Nombre;
            existingCampo.Tipo = Campo.Tipo;
            existingCampo.Ubicacion = Campo.Ubicacion;
            existingCampo.TarifaHora = Campo.TarifaHora;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampoExists(Campo.IdCampo))
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

        private bool CampoExists(int id)
        {
            return _context.Campos.Any(e => e.IdCampo == id);
        }
    }
}
