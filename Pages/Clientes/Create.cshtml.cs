using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Clientes
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly SportContext _context;
        public CreateModel(SportContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Cliente Cliente { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Clientes == null || Cliente == null)
            {
                return Page();
            }
            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
     }
}
