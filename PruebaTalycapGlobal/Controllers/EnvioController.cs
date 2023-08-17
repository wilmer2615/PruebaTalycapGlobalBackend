using DataTransferObjects;
using Logic.EnvioLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PruebaTalycapGlobal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioLogic _envioLogic;

        public EnvioController(IEnvioLogic envioLogic)
        {
            this._envioLogic = envioLogic;
        }

        /// <summary>
        /// Accion que permite hacer la creacion de un nuevo envio.
        /// </summary>
        /// <param name="envioDto">Informacion del nuevo envio.</param>
        /// <returns>Nuevo envio agregada.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnvioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] EnvioDto envioDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _envioLogic.AddAsync(envioDto));
        }

        /// <summary>
        /// Accion que permite hacer la actualizacion de un envio.
        /// </summary>
        /// <param name="envioDto">Informacion actualizada del envio .</param>
        /// <param name="id">Identificador del envio a modificar.</param>
        /// <returns>Envio actualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnvioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] EnvioDto envioDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _envioLogic.UpdateAsync(id, envioDto);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El envio no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite la eliminacion de un envio.
        /// </summary>
        /// <param name="id">Identificador del envio a eliminar.</param>
        /// <returns>Envio eliminado.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(int id)
        {
            // Se realiza la validacion.
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _envioLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El envio no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite listar los envios.
        /// </summary>
        /// <returns>Lista de envios.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _envioLogic.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Accion que permite listar un envio por Id.
        /// <param name="id">Identificador del envio.</param>
        /// </summary>
        /// <returns>Envio seleccionado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _envioLogic.FindAsync(id);
            if (result == null)
                return NotFound(new { Message = "El envio no esta registrado en la base de datos!" });

            return Ok(result);
        }
    }
}
