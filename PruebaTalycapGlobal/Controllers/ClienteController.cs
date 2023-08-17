using DataTransferObjects;
using Logic.ClienteLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PruebaTalycapGlobal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteLogic _clienteLogic;

        public ClienteController(IClienteLogic clienteLogic)
        {
            this._clienteLogic = clienteLogic;

        }

        /// <summary>
        /// Accion que permite hacer la creacion de un nuevo cliente.
        /// </summary>
        /// <param name="clienteDto">Informacion del nuevo cliente.</param>
        /// <returns>Nuevo cliente agregado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] ClienteDto clienteDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _clienteLogic.AddAsync(clienteDto));
        }

        /// <summary>
        /// Accion que permite hacer la actualizacion de un cliente.
        /// </summary>
        /// <param name="clienteDto">Informacion actualizada del cliente .</param>
        /// <param name="id">Identificador del cliente a modificar.</param>
        /// <returns>Cliente actualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDto clienteDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _clienteLogic.UpdateAsync(id, clienteDto);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { Message = "La bodega no esta registrada en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite la eliminacion de un cliente.
        /// </summary>
        /// <param name="id">Identificador del cliente a eliminar.</param>
        /// <returns>Cliente eliminado.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Remove(int id)
        {
            // Se realiza la validación.
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _clienteLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { Message = "El cliente no está registrado en la base de datos!" });

        }

        /// <summary>
        /// Accion que permite listar los clientes.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clienteLogic.GetAllAsync();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        /// <summary>
        /// Accion que permite listar una cliente por Id.
        /// <param name="id">Identificador del cliente.</param>
        /// </summary>
        /// <returns>Cliente.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _clienteLogic.FindAsync(id);
            if (result == null)
                return NotFound(new { Message = "El cliente no esta registrado en la base de datos!" });

            return Ok(result);
        }
    }
}
