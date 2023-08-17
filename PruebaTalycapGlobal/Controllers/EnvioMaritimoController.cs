using DataTransferObjects;
using Logic.EnvioMaritimoLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PruebaTalycapGlobal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioMaritimoController : ControllerBase
    {
        private readonly IEnvioMaritimoLogic _envioMaritimoLogic;

        public EnvioMaritimoController(IEnvioMaritimoLogic envioMaritimoLogic)
        {
            this._envioMaritimoLogic = envioMaritimoLogic;
        }

        /// <summary>
        /// Accion que permite hacer la creacion de un nuevo envio Maritimo.
        /// </summary>
        /// <param name="envioMaritimoDto">Informacion del nuevo envio Maritimo.</param>
        /// <returns>Nuevo envio Maritimo agregado.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnvioMaritimoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] EnvioMaritimoDto envioMaritimoDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _envioMaritimoLogic.AddAsync(envioMaritimoDto));
        }

        /// <summary>
        /// Accion que permite hacer la actualizacion de un envio Maritimo.
        /// </summary>
        /// <param name="envioMaritimoDto">Informacion actualizada del envio Maritimo.</param>
        /// <param name="id">Identificador del envio Maritimo a modificar.</param>
        /// <returns>Envio Maritimo actualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnvioMaritimoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] EnvioMaritimoDto envioMaritimoDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _envioMaritimoLogic.UpdateAsync(id, envioMaritimoDto);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El envio Maritimo no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite la eliminacion de un envio Maritimo.
        /// </summary>
        /// <param name="id">Identificador del envio Maritimo a eliminar.</param>
        /// <returns>Envio Maritimo eliminado.</returns>
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

            var result = await _envioMaritimoLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El envio Maritimo no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite listar los envios Maritimos.
        /// </summary>
        /// <returns>Lista de envios Maritimos.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _envioMaritimoLogic.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Accion que permite listar un envio Maritimo por Id.
        /// <param name="id">Identificador del envio Maritimo.</param>
        /// </summary>
        /// <returns>Envio Maritimo.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _envioMaritimoLogic.FindAsync(id);
            if (result == null)
                return NotFound(new { Message = "El envio Maritimo no esta registrado en la base de datos!" });

            return Ok(result);
        }
    }
}
