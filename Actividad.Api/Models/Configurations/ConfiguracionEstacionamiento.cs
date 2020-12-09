using Actividad.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Actividad.Api.Models.Configurations
{
    public class ConfiguracionEstacionamiento : IEntityTypeConfiguration<Estacionamiento>
    {
        public void Configure(EntityTypeBuilder<Estacionamiento> builder)
        {
            builder.ToTable("Estacionamientos").HasComment("Producto del servicio");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Nombre).IsRequired();
            builder.Property(e => e.Descripcion).IsRequired();
            builder.Property(e => e.Costo).IsRequired().HasPrecision(8,2);
            builder.Property(e => e.Calificacion).IsRequired().HasPrecision(8, 2);
            builder.Property(e => e.Numero).IsRequired();
            builder.Property(e => e.Calle).IsRequired();
            builder.Property(e => e.Colonia).IsRequired();
            builder.Property(e => e.CodigoPostal).IsRequired();
            builder.Property(e => e.Municipio).IsRequired();
            builder.Property(e => e.Latitud).IsRequired();
            builder.Property(e => e.Longitud).IsRequired();

            builder.HasData
            (
                new Estacionamiento
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Revolucionario",
                    Descripcion = "El más barato de revolución",
                    Calificacion = 5,
                    Costo = 15,
                    Numero = "1",
                    Calle = "A",
                    Colonia = "Colonia A",
                    CodigoPostal = "28001",
                    Municipio = "Colima",
                    Latitud = "19.239937687163206",
                    Longitud = "-103.7237955329542"
                },
                new Estacionamiento
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Libertad",
                    Descripcion = "Ecoestacionamiento reformado",
                    Calificacion = 5,
                    Costo = 15,
                    Numero = "2",
                    Calle = "B",
                    Colonia = "Colonia B",
                    CodigoPostal = "28002",
                    Municipio = "Colima",
                    Latitud = "19.24303615160122",
                    Longitud = "-103.72825568830704"
                },
                new Estacionamiento
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Marina",
                    Descripcion = "Ecoestacionamiento constituido",
                    Calificacion = 4.8M,
                    Costo = 10,
                    Numero = "3",
                    Calle = "C",
                    Colonia = "Colonia C",
                    CodigoPostal = "28003",
                    Municipio = "Colima",
                    Latitud = "19.251725404009665",
                    Longitud = "-103.72085671842486"
                },
                new Estacionamiento
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Zentralia",
                    Descripcion = "Estacionamiento comercial",
                    Calificacion = 4.3M,
                    Costo = 20,
                    Numero = "4",
                    Calle = "D",
                    Colonia = "Colonia D",
                    CodigoPostal = "28004",
                    Municipio = "Colima",
                    Latitud = "19.266306310173388",
                    Longitud = "-103.6974779386686"
                },
                new Estacionamiento
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Homedepot",
                    Descripcion = "Estacionamiento constructivo",
                    Calificacion = 4.3M,
                    Costo = 7,
                    Numero = "5",
                    Calle = "E",
                    Colonia = "Colonia E",
                    CodigoPostal = "28005",
                    Municipio = "Colima",
                    Latitud = "19.26394166716784",
                    Longitud = "-103.69400342671413"
                },
                new Estacionamiento
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Ucol",
                    Descripcion = "Estacionamiento enfermeroso",
                    Calificacion = 4.3M,
                    Costo = 7,
                    Numero = "6",
                    Calle = "E",
                    Colonia = "Colonia E",
                    CodigoPostal = "28005",
                    Municipio = "Colima",
                    Latitud = "19.24753137463207",
                    Longitud = "-103.69879772258632"
                },
                new Estacionamiento
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Ecoparque",
                    Descripcion = "Estacionamiento ecológico",
                    Calificacion = 4.6M,
                    Costo = 9,
                    Numero = "7",
                    Calle = "F",
                    Colonia = "Colonia F",
                    CodigoPostal = "28006",
                    Municipio = "Colima",
                    Latitud = "19.238138704563717",
                    Longitud = "-103.73356469917077"
                },
                new Estacionamiento
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Piedra lisa",
                    Descripcion = "Estacionamiento ecológico",
                    Calificacion = 4.6M,
                    Costo = 9,
                    Numero = "8",
                    Calle = "F",
                    Colonia = "Colonia F",
                    CodigoPostal = "28006",
                    Municipio = "Colima",
                    Latitud = "19.238138704563717",
                    Longitud = "-103.73356469917077"
                }
            );
        }
    }
}
