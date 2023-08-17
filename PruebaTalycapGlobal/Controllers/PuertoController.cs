using DataTransferObjects;
using Logic.PuertoLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PruebaTalycapGlobal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuertoController : ControllerBase
    {
        private readonly IPuertoLogic _puertoLogic;

        public PuertoController(IPuertoLogic puertoLogic)
        {
            this._puertoLogic = puertoLogic;
        }

        /// <summary>
        /// Accion que permite hacer la creacion de un nuevo puerto.
        /// </summary>
        /// <param name="puertoDto">Informacion del nuevo puerto.</param>
        /// <returns>Nuevo puerto agregado.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PuertoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] PuertoDto puertoDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _puertoLogic.AddAsync(puertoDto));
        }

        /// <summary>
        /// Accion que permite hacer la actualizacion de un puerto.
        /// </summary>
        /// <param name="puertoDto">Informacion actualizada del puerto .</param>
        /// <param name="id">Identificador del puerto a modificar.</param>
        /// <returns>Puerto actualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BodegaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] PuertoDto puertoDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _puertoLogic.UpdateAsync(id, puertoDto);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El puerto no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite la eliminacion de un puerto.
        /// </summary>
        /// <param name="id">Identificador del puerto a eliminar.</param>
        /// <returns>Puerto eliminado.</returns>
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

            var result = await _puertoLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El puerto no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite listar los puertos.
        /// </summary>
        /// <returns>Lista de puertos.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _puertoLogic.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Accion que permite listar un puerto por Id.
        /// <param name="id">Identificador del puerto.</param>
        /// </summary>
        /// <returns>Puerto.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _puertoLogic.FindAsync(id);
            if (result == null)
                return NotFound(new { Message = "El puerto no esta registrado en la base de datos!" });

            return Ok(result);
        }
    }
}
