using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportFieldBooking.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }

        // FK a Campo
        public int IdCampo { get; set; }
        public Campo? Campo { get; set; }

        // FK a Cliente
        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }

        public DateTime FechaHoraInicio { get; set; }

        public DateTime FechaHoraFin { get; set; }

        public string Estado { get; set; }  // Reservado, Cancelado, Completado

        // Relación uno a uno con Pago
        public Pago? Pago { get; set; }
    }
}
