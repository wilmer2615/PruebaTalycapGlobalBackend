using DataTransferObjects;
using Logic.EnvioTerrestreLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PruebaTalycapGlobal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioTerrestreController : ControllerBase
    {
        private readonly IEnvioTerrestreLogic _envioTerrestreLogic;

        public EnvioTerrestreController(IEnvioTerrestreLogic envioTerrestreLogic)
        {
            this._envioTerrestreLogic = envioTerrestreLogic;
        }

        /// <summary>
        /// Accion que permite hacer la creacion de un nuevo envio terrestre.
        /// </summary>
        /// <param name="envioTerrestreDto">Informacion del nuevo envio terrestre.</param>
        /// <returns>Nuevo envio terrestre agregado.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnvioTerrestreDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] EnvioTerrestreDto envioTerrestreDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _envioTerrestreLogic.AddAsync(envioTerrestreDto));
        }

        /// <summary>
        /// Accion que permite hacer la actualizacion de un envio terrestre.
        /// </summary>
        /// <param name="envioTerrestreDto">Informacion actualizada del envio terrestre.</param>
        /// <param name="id">Identificador del envio terrestre a modificar.</param>
        /// <returns>Envio terrestre actualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnvioTerrestreDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] EnvioTerrestreDto envioTerrestreDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _envioTerrestreLogic.UpdateAsync(id, envioTerrestreDto);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El envio terrestre no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite la eliminacion de un envio terrestre.
        /// </summary>
        /// <param name="id">Identificador del envio terrestre a eliminar.</param>
        /// <returns>Envio terrestre eliminado.</returns>
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

            var result = await _envioTerrestreLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El envio terrestre no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite listar los envios terrestres.
        /// </summary>
        /// <returns>Lista de envios terrestres.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _envioTerrestreLogic.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Accion que permite listar un envio terrestre por Id.
        /// <param name="id">Identificador del envio terrestre.</param>
        /// </summary>
        /// <returns>Envio terrestre.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _envioTerrestreLogic.FindAsync(id);
            if (result == null)
                return NotFound(new { Message = "El envio terrestre no esta registrado en la base de datos!" });

            return Ok(result);
        }
    }
}
