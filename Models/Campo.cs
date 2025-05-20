namespace SportFieldBooking.Models
{
    public class Campo
    {
        public int IdCampo { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }  // Fútbol, Básquetbol, Tenis, etc.

        public string Ubicacion { get; set; }

        public decimal TarifaHora { get; set; }

        // Relación uno a muchos con Reservas
        public ICollection<Reserva>? Reservas { get; set; } = new List<Reserva>();

        // Relación uno a muchos con Eventos
        public ICollection<Evento>? Eventos { get; set; } = new List<Evento>();
    }
}
