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
    public class EstacionamientosController : ControllerBase
    {
        public EstacionamientosController(IRepositorioEstacionamientos estacionamientos) => this.Estacionamientos = estacionamientos;

        private IRepositorioEstacionamientos Estacionamientos { get; }

        // GET: api/Estacionamientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estacionamiento>>> Get()
        {
            try
            {
                return await this.Estacionamientos.ObtenerTodoAsync();
            }
            catch (Exception exception)
            {
                return this.Problem(exception.Message, title: "Error obteniendo estacionamientos");
            }
        }

        // GET: api/Estacionamientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estacionamiento>> Get(string id)
        {
            try
            {
                return await this.Estacionamientos.ObtenerAsync(id);
            }
            catch (Exception exception)
            {
                return this.Problem(exception.Message, title: "Error obteniendo estacionamiento");
            }
        }

        // PUT: api/Estacionamientos
        [HttpPut]
        public async Task<IActionResult> Put(Estacionamiento estacionamiento)
        {
            try
            {
                await this.Estacionamientos.EditarAsync(estacionamiento);

                return this.NoContent();
            }
            catch (Exception exception)
            {
                return this.Problem(exception.Message, title: "Error editando estacionamiento");
            }
        }

        // POST: api/Estacionamientos
        [HttpPost]
        public async Task<IActionResult> Post(Estacionamiento usuario)
        {
            try
            {
                await this.Estacionamientos.CrearAsync(usuario);

                return this.NoContent();
            }
            catch (Exception exception)
            {
                return this.Problem(exception.Message, title: "Error creando estacionamiento");
            }
        }

        // DELETE: api/Estacionamientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.Estacionamientos.BorrarAsync(id);

                return this.NoContent();
            }
            catch (Exception exception)
            {
                return this.Problem(exception.Message, title: "Error borrando estacionamiento");
            }
        }
    }
}
