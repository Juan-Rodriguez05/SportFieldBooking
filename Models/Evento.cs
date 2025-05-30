using System.ComponentModel.DataAnnotations;

namespace SportFieldBooking.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }

        // FK a Campo
        [Required]
        public int IdCampo { get; set; }
        public Campo? Campo { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string NombreEvento { get; set; } = string.Empty;

        [Required]
        public DateTime FechaEvento { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }

        public string Descripcion { get; set; } = string.Empty;
    }
}
