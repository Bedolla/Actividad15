using Actividad.Data.Dtos;
using Actividad.Data.Entities;
using Actividad.Mobile.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Actividad.Mobile.Services
{
    public interface IServicioEstacionamientos
    {
        Task<List<Estacionamiento>> ObtenerTodosAsync(PaginacionPeticion paginacion);
        Task<List<Estacionamiento>> ObtenerTodosAsync();
        Task<Estacionamiento> ObtenerAsync(string id);
        Task CrearAsync(Estacionamiento modelo);
        Task EditarAsync(Estacionamiento modelo);
        Task BorrarAsync(string id);
    }

    internal class ServicioEstacionamientos : IServicioEstacionamientos
    {
        public ServicioEstacionamientos(HttpClient cliente) => this.Cliente = cliente;

        private HttpClient Cliente { get; }

        public async Task<List<Estacionamiento>> ObtenerTodosAsync(PaginacionPeticion paginacion) =>
            await this.Cliente.GetJsonAsync<List<Estacionamiento>>(QueryHelpers.AddQueryString("Usuarios", new Dictionary<string, string>
            {
                {"TerminoBuscado", paginacion.TerminoBuscado},
                {"OrdenarPor", paginacion.OrdenarPor},
                {"NumeroPagina", paginacion.NumeroPagina.ToString()},
                {"CantidadPorPagina", paginacion.CantidadPorPagina.ToString()}
            }));

        public async Task<List<Estacionamiento>> ObtenerTodosAsync() => await this.Cliente.GetJsonAsync<List<Estacionamiento>>("Estacionamientos");

        public async Task<Estacionamiento> ObtenerAsync(string id) => await this.Cliente.GetJsonAsync<Estacionamiento>($"Estacionamientos/{id}");

        public async Task CrearAsync(Estacionamiento modelo) => await this.Cliente.PostJsonAsync("Estacionamientos", modelo);

        public async Task EditarAsync(Estacionamiento modelo) => await this.Cliente.PutJsonAsync("Estacionamientos", modelo);

        public async Task BorrarAsync(string id) => await this.Cliente.DeleteJsonAsync($"Estacionamientos/{id}");
    }
}
