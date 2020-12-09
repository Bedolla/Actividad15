using Actividad.Data.Dtos;
using Actividad.Data.Entities;
using Actividad.Mobile.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Actividad.Mobile.Services
{
    public interface IServicioUsuarios
    {
        Task<List<Usuario>> ObtenerTodosAsync(PaginacionPeticion paginacion);
        Task<List<Usuario>> ObtenerTodosAsync();
        Task<Usuario> ObtenerAsync(string id);
        Task CrearAsync(Usuario modelo);
        Task EditarAsync(Usuario modelo);
        Task BorrarAsync(string id);
    }

    internal class ServicioUsuarios : IServicioUsuarios
    {
        public ServicioUsuarios(HttpClient cliente) => this.Cliente = cliente;

        private HttpClient Cliente { get; }

        public async Task<List<Usuario>> ObtenerTodosAsync(PaginacionPeticion paginacion) =>
            await this.Cliente.GetJsonAsync<List<Usuario>>(QueryHelpers.AddQueryString("Usuarios", new Dictionary<string, string>
            {
                {"TerminoBuscado", paginacion.TerminoBuscado},
                {"OrdenarPor", paginacion.OrdenarPor},
                {"NumeroPagina", paginacion.NumeroPagina.ToString()},
                {"CantidadPorPagina", paginacion.CantidadPorPagina.ToString()}
            }));

        public async Task<List<Usuario>> ObtenerTodosAsync() => await this.Cliente.GetJsonAsync<List<Usuario>>("Usuarios");

        public async Task<Usuario> ObtenerAsync(string id) => await this.Cliente.GetJsonAsync<Usuario>($"Usuarios/{id}");

        public async Task CrearAsync(Usuario modelo) => await this.Cliente.PostJsonAsync("Usuarios", modelo);

        public async Task EditarAsync(Usuario modelo) => await this.Cliente.PutJsonAsync("Usuarios", modelo);

        public async Task BorrarAsync(string id) => await this.Cliente.DeleteJsonAsync($"Usuarios/{id}");
    }
}
