using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Reservas
{
    public class CreateModel : PageModel
    {
        private readonly SportContext _context;

        public CreateModel(SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = default!;

        public IActionResult OnGet()
        {
            ViewData["IdCampo"] = new SelectList(_context.Campos, "IdCampo", "Nombre");
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Nombre");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}