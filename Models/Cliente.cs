namespace SportFieldBooking.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        // Relación uno a muchos con Reservas
        public ICollection<Reserva>? Reservas { get; set; } = new List<Reserva>();
    }
}
