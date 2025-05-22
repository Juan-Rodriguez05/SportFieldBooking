using System.ComponentModel.DataAnnotations;

namespace SportFieldBooking.Models
{
    public class Campo
    {
        public int IdCampo { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty; // Fútbol, Básquetbol, Tenis, etc.

        public string Ubicacion { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TarifaHora { get; set; }

        // Relación uno a muchos con Reservas
        public ICollection<Reserva>? Reservas { get; set; } = new List<Reserva>();

        // Relación uno a muchos con Eventos
        public ICollection<Evento>? Eventos { get; set; } = new List<Evento>();
    }
}
