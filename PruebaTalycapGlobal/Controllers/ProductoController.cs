using DataTransferObjects;
using Logic.ProductoLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PruebaTalycapGlobal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoLogic _productoLogic;

        public ProductoController(IProductoLogic productoLogic)
        {
            this._productoLogic = productoLogic;
        }

        /// <summary>
        /// Accion que permite hacer la creacion de un nuevo producto.
        /// </summary>
        /// <param name="productoDto">Informacion del nuevo producto.</param>
        /// <returns>Nuevo producto agregado.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] ProductoDto productoDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _productoLogic.AddAsync(productoDto));
        }

        /// <summary>
        /// Accion que permite hacer la actualizacion de un producto.
        /// </summary>
        /// <param name="productoDto">Informacion actualizada del producto.</param>
        /// <param name="id">Identificador del producto a modificar.</param>
        /// <returns>Producto actualizada.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] ProductoDto productoDto)
        {
            // Se realiza la validacion del modelo.
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _productoLogic.UpdateAsync(id, productoDto);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El producto no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite la eliminacion de un producto.
        /// </summary>
        /// <param name="id">Identificador del producto a eliminar.</param>
        /// <returns>Producto eliminado.</returns>
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

            var result = await _productoLogic.RemoveAsync(id);

            if (result != null)
            {
                return Ok();
            }
            return NotFound(new { Message = "El producto no esta registrado en la base de datos!" });
        }

        /// <summary>
        /// Accion que permite listar los productos.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productoLogic.GetAllAsync();
            return Ok(result);
        }

        /// <summary>
        /// Accion que permite listar un producto por Id.
        /// <param name="id">Identificador del producto.</param>
        /// </summary>
        /// <returns>Producto.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _productoLogic.FindAsync(id);
            if (result == null)
                return NotFound(new { Message = "El producto no esta registrado en la base de datos!" });

            return Ok(result);
        }
    }
}
