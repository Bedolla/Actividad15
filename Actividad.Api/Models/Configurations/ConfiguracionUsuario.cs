using Actividad.Data.Constants;
using Actividad.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Actividad.Api.Models.Configurations
{
    public class ConfiguracionUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios").HasComment("Administradores del servicio");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.Nombre).IsRequired();
            builder.Property(u => u.Apellido).IsRequired();
            builder.Property(u => u.Correo).IsRequired();
            builder.Property(u => u.Clave).IsRequired();
            builder.Property(u => u.Foto).IsRequired();
            builder.Property(u => u.Creacion).IsRequired().HasColumnType("DateTime2");
            builder.Property(u => u.Disponible).IsRequired();
            builder.Property(u => u.Rol).IsRequired();

            builder.HasData
            (
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Juan Carlos",
                    Apellido = "Flores Avalos",
                    Correo = "flores@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Francisco Javier",
                    Apellido = "Galván Guerrero",
                    Correo = "galvan@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "María Guadalupe",
                    Apellido = "Alvarez Negrete",
                    Correo = "alvarez@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "María Enriqueta",
                    Apellido = "Rego Rodriguez",
                    Correo = "rego@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Sergio Adrían",
                    Apellido = "Montaño Araujo",
                    Correo = "montano@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Edgar Ramón",
                    Apellido = "Carrasco García",
                    Correo = "carrasco@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Alejandro Ismael",
                    Apellido = "Negrete Borjas",
                    Correo = "negrete@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Esli",
                    Apellido = "Castellanos Berjan",
                    Correo = "castellanos@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Joel Alejandro",
                    Apellido = "Serrano Ramos",
                    Correo = "serrano@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Fernando Alfonso",
                    Apellido = "Flores Ruelas",
                    Correo = "flores@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Hernán Adalid",
                    Apellido = "Escalera Pérez",
                    Correo = "escalera@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/soporte/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Soporte
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Fernando",
                    Apellido = "Bedolla Valencia",
                    Correo = "bedolla@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/administradores/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Administrador
                },
                new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Administrador",
                    Apellido = "General",
                    Correo = "a@ucol.mx",
                    Clave = "OGgFiKDvH7RfNOasdZLhfw==",
                    Foto = $"img/avatares/administradores/{Guid.NewGuid()}.png",
                    Creacion = DateTime.Now,
                    Disponible = true,
                    Rol = Roles.Administrador
                }
            );
        }
    }
}
