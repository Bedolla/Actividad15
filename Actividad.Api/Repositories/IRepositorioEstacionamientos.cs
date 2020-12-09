using Actividad.Api.Models;
using Actividad.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad.Api.Repositories
{
    public interface IRepositorioEstacionamientos
    {
        Task<List<Estacionamiento>> ObtenerTodoAsync();
        Task<Estacionamiento> ObtenerAsync(string id);
        Task CrearAsync(Estacionamiento modelo);
        Task EditarAsync(Estacionamiento modelo);
        Task BorrarAsync(string id);
    }

    public class RepositorioEstacionamientos : IRepositorioEstacionamientos
    {
        public RepositorioEstacionamientos(Contexto contexto) => this.Contexto = contexto;

        private Contexto Contexto { get; }

        public async Task<List<Estacionamiento>> ObtenerTodoAsync() =>
            await this.Contexto.Estacionamientos
                      .OrderBy(e => e.Municipio)
                      .ThenBy(e => e.Colonia)
                      .ThenBy(e => e.Calle)
                      .ThenBy(e => e.Nombre)
                      .ToListAsync();

        public async Task<Estacionamiento> ObtenerAsync(string id) => await this.Contexto.Estacionamientos.FindAsync(id);

        public async Task CrearAsync(Estacionamiento modelo)
        {
            await this.Contexto.Estacionamientos.AddAsync(modelo);

            await this.Contexto.SaveChangesAsync();
        }

        public async Task EditarAsync(Estacionamiento modelo)
        {
            try
            {
                Estacionamiento estacionamiento = await this.Contexto.Estacionamientos.FindAsync(modelo.Id);

                if (estacionamiento is null) throw new Exception("Estacionamiento no encontrado");

                estacionamiento.Nombre = modelo.Nombre;
                estacionamiento.Descripcion = modelo.Descripcion;
                estacionamiento.Costo = modelo.Costo;
                estacionamiento.Calificacion = modelo.Calificacion;
                estacionamiento.Numero = modelo.Numero;
                estacionamiento.Calle = modelo.Calle;
                estacionamiento.Colonia = modelo.Colonia;
                estacionamiento.CodigoPostal = modelo.CodigoPostal;
                estacionamiento.Municipio = modelo.Municipio;
                estacionamiento.Latitud = modelo.Latitud;
                estacionamiento.Longitud = modelo.Longitud;

                this.Contexto.Estacionamientos.Update(estacionamiento);

                await this.Contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await this.Contexto.Estacionamientos.AllAsync(r => r.Id != modelo.Id)) throw new Exception("El estacionamiento ya no existe");
                throw new Exception("El estacionamiento fue modificado por alguien más mientras usted trataba de editarlo");
            }
        }

        public async Task BorrarAsync(string id)
        {
            try
            {
                Estacionamiento estacionamiento = await this.Contexto.Estacionamientos.FindAsync(id);

                if (estacionamiento is null) throw new Exception("estacionamiento no encontrado");

                this.Contexto.Estacionamientos.Remove(estacionamiento);

                await this.Contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await this.Contexto.Estacionamientos.AllAsync(r => r.Id != id)) throw new Exception("El estacionamiento ya no existe");
                throw new Exception("El estacionamiento fue modificado por alguien más mientras usted trataba de borrarlo");
            }
        }
    }
}
