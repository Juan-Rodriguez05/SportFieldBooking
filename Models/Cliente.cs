namespace SportFieldBooking.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        // Relación uno a muchos con Reservas
        public ICollection<Reserva>? Reservas { get; set; } = new List<Reserva>();
    }
}
