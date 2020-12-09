using Actividad.Api.Models;
using Actividad.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad.Api.Repositories
{
    public interface IRepositorioUsuarios
    {
        Task<List<Usuario>> ObtenerTodoAsync();
        Task<Usuario> ObtenerAsync(string id);
        Task CrearAsync(Usuario modelo);
        Task EditarAsync(Usuario modelo);
        Task BorrarAsync(string id);
    }

    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        public RepositorioUsuarios(Contexto contexto) => this.Contexto = contexto;

        private Contexto Contexto { get; }

        public async Task<List<Usuario>> ObtenerTodoAsync() =>
            await this.Contexto.Usuarios
                      .OrderBy(u => u.Apellido)
                      .ThenBy(u => u.Nombre)
                      .ThenBy(u => u.Correo)
                      .ToListAsync();

        public async Task<Usuario> ObtenerAsync(string id) => await this.Contexto.Usuarios.FirstOrDefaultAsync(u => (u.Id == id) || (u.Correo == id));

        public async Task CrearAsync(Usuario modelo)
        {
            if (await this.Contexto.Usuarios.AnyAsync(u => u.Correo.Equals(modelo.Correo))) throw new Exception("Correo ya registrado");

            await this.Contexto.Usuarios.AddAsync(modelo);

            await this.Contexto.SaveChangesAsync();
        }

        public async Task EditarAsync(Usuario modelo)
        {
            try
            {
                Usuario usuario = await this.Contexto.Usuarios.FindAsync(modelo.Id);

                if (usuario is null) throw new Exception("Usuario no encontrado");

                usuario.Nombre = modelo.Nombre;
                usuario.Apellido = modelo.Apellido;
                usuario.Correo = modelo.Correo;
                usuario.Clave = modelo.Clave;
                usuario.Foto = modelo.Foto;

                if (await this.Contexto.Usuarios.AnyAsync(u => u.Correo.Equals(usuario.Correo) && (u.Id != usuario.Id))) throw new Exception("Correo ya registrado");

                this.Contexto.Usuarios.Update(usuario);

                await this.Contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await this.Contexto.Usuarios.AllAsync(r => r.Id != modelo.Id)) throw new Exception("El usuario ya no existe");
                throw new Exception("El usuario fue modificado por alguien más mientras usted trataba de editarlo");
            }
        }

        public async Task BorrarAsync(string id)
        {
            try
            {
                Usuario usuario = await this.Contexto.Usuarios.FindAsync(id);

                if (usuario is null) throw new Exception("Usuario no encontrado");

                this.Contexto.Usuarios.Remove(usuario);

                await this.Contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await this.Contexto.Usuarios.AllAsync(r => r.Id != id)) throw new Exception("El usuario ya no existe");
                throw new Exception("El usuario fue modificado por alguien más mientras usted trataba de borrarlo");
            }
        }
    }
}
