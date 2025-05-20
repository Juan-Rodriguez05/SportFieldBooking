namespace SportFieldBooking.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }

        // FK a Campo
        public int IdCampo { get; set; }
        public Campo? Campo { get; set; }

        public string NombreEvento { get; set; }

        public DateTime FechaEvento { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin { get; set; }

        public string Descripcion { get; set; }
    }
}
