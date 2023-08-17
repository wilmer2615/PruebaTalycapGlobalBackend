using DataTransferObjects;
using Logic.BodegaLogic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PruebaTalycapGlobal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegaController : ControllerBase
    {
        private readonly IBodegaLogic _bodegaLogic;

        public BodegaController(IBodegaLogic bodegaLogic)
        {
            this._bodegaLogic = bodegaLogic;
        }

        /// <summary>
        /// Accion que permite hacer la creacion de una nueva bodega.
        /// </summary>
        /// <param name="bodegaDto">Informacion de la nueva bodega.</param>
        /// <returns>Nueva bodega agregada.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BodegaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] BodegaDto bodegaDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _bodegaLogic.AddAsync(bodegaDto));
        }

        /// <summary>
        /// Accion que permite hacer la actualizacion de una bodega.
        /// </summary>
        /// <param name="bodegaDto">Informacion actualizada de la bodega .</param>
        /// <param name="id">Identificador de la bodega a modificar.</param>
        /// <returns>Bodega actualizada.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BodegaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] BodegaDto bodegaDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _bodegaLogic.UpdateAsync(id, bodegaDto);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "La bodega no esta registrada en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite la eliminacion de una bodega.
        /// </summary>
        /// <param name="id">Identificador de la bodega a eliminar.</param>
        /// <returns>Bodega eliminada.</returns>
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

            var result = await _bodegaLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "La bodega no esta registrada en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite listar las bodegas.
        /// </summary>
        /// <returns>Lista de bodegas.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bodegaLogic.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Accion que permite listar una bodega por Id.
        /// <param name="id">Identificador de la bodega.</param>
        /// </summary>
        /// <returns>Bodega.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _bodegaLogic.FindAsync(id);
            if (result == null)
                return NotFound(new { Message = "La bodega no esta registrada en la base de datos!" });

            return Ok(result);
        }
    }
}
