using Actividad.Api.Models.Configurations;
using Actividad.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Actividad.Api.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<Estacionamiento> Estacionamientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer
                (
                    new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("AppSettings.json")
                        .Build()
                        .GetConnectionString("Local")
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfiguracionUsuario());
            modelBuilder.ApplyConfiguration(new ConfiguracionEstacionamiento());
        }
    }
}
