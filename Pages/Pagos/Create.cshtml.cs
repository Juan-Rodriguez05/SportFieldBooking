using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SportFieldBooking.Pages.Pagos
{
    [Authorize]
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
            var reservasSinPago = _context.Reservas
                .Include(r => r.Cliente)
                .Where(r => !_context.Pagos.Any(p => p.IdReserva == r.IdReserva))
                .Select(r => new
                {
                    r.IdReserva,
                    Display = $"Reserva {r.IdReserva} - {r.Cliente!.Nombre} {r.Cliente!.Apellido} - {r.FechaHoraInicio:dd/MM/yyyy HH:mm}"
                })
                .ToList();

            ViewData["IdReserva"] = new SelectList(reservasSinPago, "IdReserva", "Display");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Pago == null)
            {
                // Recargar reservas para el dropdown en caso de error
                var reservasSinPago = _context.Reservas
                    .Include(r => r.Cliente)
                    .Where(r => !_context.Pagos.Any(p => p.IdReserva == r.IdReserva))
                    .Select(r => new
                    {
                        r.IdReserva,
                        Display = $"Reserva {r.IdReserva} - {r.Cliente!.Nombre} {r.Cliente!.Apellido} - {r.FechaHoraInicio:dd/MM/yyyy HH:mm}"
                    })
                    .ToList();

                ViewData["IdReserva"] = new SelectList(reservasSinPago, "IdReserva", "Display");

                return Page();
            }

            Pago.FechaPago = DateTime.Now;

            _context.Pagos.Add(Pago);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al guardar el pago: {ex.Message}");

                var reservasSinPago = _context.Reservas
                    .Include(r => r.Cliente)
                    .Where(r => !_context.Pagos.Any(p => p.IdReserva == r.IdReserva))
                    .Select(r => new
                    {
                        r.IdReserva,
                        Display = $"Reserva {r.IdReserva} - {r.Cliente!.Nombre} {r.Cliente!.Apellido} - {r.FechaHoraInicio:dd/MM/yyyy HH:mm}"
                    })
                    .ToList();

                ViewData["IdReserva"] = new SelectList(reservasSinPago, "IdReserva", "Display");

                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
