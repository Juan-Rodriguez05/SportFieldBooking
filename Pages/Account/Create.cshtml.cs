using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly SportContext _context;

        public CreateModel(SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = new();

        public List<SelectListItem> RoleOptions { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Administrador", Text = "Administrador" },
            new SelectListItem { Value = "Usuario", Text = "Usuario" }
        };

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var exists = _context.Users.Any(u => u.Email == User.Email);
            if (exists)
            {
                ModelState.AddModelError(string.Empty, "Ya existe una cuenta con este correo.");
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("Login");
        }
    }
}
