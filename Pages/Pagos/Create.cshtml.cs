using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Pagos
{
    public class CreateModel : PageModel
    {
        private readonly SportContext _context;

        public CreateModel(SportContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Pago Pago { get; set; } = default!;
        public IActionResult OnGet()
        {
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _context.Pagos == null || Pago == null)
            {
                ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");

                return Page();
            }

            Pago.FechaPago = DateTime.Now;

            _context.Pagos.Add(Pago);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
