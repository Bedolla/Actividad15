using Actividad.Api.Repositories;
using Actividad.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actividad.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public UsuariosController(IRepositorioUsuarios usuarios) => this.Usuarios = usuarios;

        private IRepositorioUsuarios Usuarios { get; }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            try
            {
                return await this.Usuarios.ObtenerTodoAsync();
            }
            catch (Exception exception)
            {
                return this.Problem(exception.Message, title: "Error obteniendo usuarios");
            }
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(string id)
        {
            try
            {
                return await this.Usuarios.ObtenerAsync(id);
            }
            catch (Exception exception)
            {
                return this.Problem(exception.Message, title: "Error obteniendo usuario");
            }
        }

        // PUT: api/Usuarios
        [HttpPut]
        public async Task<IActionResult> Put(Usuario usuario)
        {
            try
            {
                await this.Usuarios.EditarAsync(usuario);

                return this.NoContent();
            }
            catch (Exception exception)
            {
                return this.Problem(exception.Message, title: "Error editando usuario");
            }
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                await this.Usuarios.CrearAsync(usuario);

                return this.NoContent();
            }
            catch (Exception exception)
            {
                return this.Problem(exception.Message, title: "Error creando usuario");
            }
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.Usuarios.BorrarAsync(id);

                return this.NoContent();
            }
            catch (Exception exception)
            {
                return this.Problem(exception.Message, title: "Error borrando usuario");
            }
        }
    }
}
