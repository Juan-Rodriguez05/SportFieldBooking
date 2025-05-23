﻿using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Models;

namespace SportFieldBooking.Data
{
    public class SportContext : DbContext
    {
        public SportContext(DbContextOptions<SportContext> options) : base(options)
        {
        }
        public DbSet<Campo> Campos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Campo>()
                .HasKey(c => c.IdCampo);
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.IdCliente);
            modelBuilder.Entity<Evento>()
                .HasKey(e => e.IdEvento);
            modelBuilder.Entity<Pago>()
                .HasKey(p => p.IdPago);
            modelBuilder.Entity<Reserva>()
                .HasKey(r => r.IdReserva);


            // Configurar relación uno a uno entre Reserva y Pago
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Pago)
                .WithOne(p => p.Reserva)
                .HasForeignKey<Pago>(p => p.IdReserva)
                .OnDelete(DeleteBehavior.Cascade); // Funciona para cuando se elimine la reseva tambien el pago que se hara

        }

    }
}
