using System.ComponentModel.DataAnnotations;

namespace SportFieldBooking.Models
{
    public class Pago
    {
        public int IdPago { get; set; }

        // FK a Reserva
        [Required]
        public int IdReserva { get; set; }
        public Reserva? Reserva { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }

        public string MetodoPago { get; set; } = string.Empty; // Tarjeta, Efectivo, etc.
    }
}
