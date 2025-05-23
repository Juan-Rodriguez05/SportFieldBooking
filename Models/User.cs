using System.ComponentModel.DataAnnotations;

namespace SportFieldBooking.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [RegularExpression("^(Usuario|Administrador)$", ErrorMessage = "El rol debe ser 'Usuario' o 'Administrador'.")]
        public string Role { get; set; } = "Usuario";
    }
}
