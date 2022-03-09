using Microsoft.EntityFrameworkCore;
using Prueba.VivaVolar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.VivaVolar.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
        }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Vuelos> Vuelos { get; set; }
        public DbSet<Reservas> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.idUsuario).HasColumnName("idUsuario");
                entity.Property(e => e.Usuario).HasColumnName("Usuario");
                entity.Property(e => e.NombreUsuario).HasColumnName("NombreUsuario");
                entity.Property(e => e.PassUser).HasColumnName("PassUser");
                entity.Property(e => e.Email).HasColumnName("Email");
                entity.Property(e => e.idTipoUser).HasColumnName("idTipoUser");
                entity.Property(e => e.UsuarioIdentificacion).HasColumnName("UsuarioIdentificacion");
                entity.Property(e => e.TipoIdentificacion).HasColumnName("TipoIdentificacion");
            });

            modelBuilder.Entity<Vuelos>(entity =>
            {
                entity.ToTable("Vuelos");

                entity.Property(e => e.idVuelo).HasColumnName("idVuelo");
                entity.Property(e => e.NumeroVuelo).HasColumnName("NumeroVuelo");
                entity.Property(e => e.FechaDisponibilidad).HasColumnName("FechaDisponibilidad");
                entity.Property(e => e.CantidadSilla).HasColumnName("CantidadSilla");
                entity.Property(e => e.CiudadOrigen).HasColumnName("CiudadOrigen");
                entity.Property(e => e.CiudadDestino).HasColumnName("CiudadDestino");
                entity.Property(e => e.Precio).HasColumnName("Precio");   
            });

            modelBuilder.Entity<Reservas>(entity =>
            {
                entity.ToTable("Reservas");

                entity.Property(e => e.idReserva).HasColumnName("idReserva");
                entity.Property(e => e.idUsuario).HasColumnName("idUsuario");
                entity.Property(e => e.idVuelo).HasColumnName("idVuelo"); 
            });
        }
    }
}
