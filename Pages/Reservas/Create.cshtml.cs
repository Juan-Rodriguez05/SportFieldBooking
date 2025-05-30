using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Reservas
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
        public Reserva Reserva { get; set; } = default!;

        public SelectList Campos { get; set; } = default!;
        public SelectList Clientes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Campos = new SelectList(await _context.Campos.ToListAsync(), "IdCampo", "Nombre");
            Clientes = new SelectList(
            await _context.Clientes
           .Select(c => new { c.IdCliente, NombreCompleto = c.Nombre + " " + c.Apellido })
           .ToListAsync(),
           "IdCliente",
           "NombreCompleto");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Campos = new SelectList(await _context.Campos.ToListAsync(), "IdCampo", "Nombre");
                Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "NombreCompleto");
                return Page();
            }

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}