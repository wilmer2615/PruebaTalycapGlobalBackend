using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class ProductoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo de producto es requerido")]
        public string TipoProducto { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public string DescripcionProducto { get; set; }
    }
}
