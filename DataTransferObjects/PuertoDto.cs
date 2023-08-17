using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class PuertoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La ubicacion es requerida")]
        public string Ubicacion { get; set; }
    }
}
