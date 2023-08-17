using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class ClienteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La direccion es requerida")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El numero de identificacion es requerido")]
        [StringLength(10, ErrorMessage = "La longitud maxima para el campo NumeroIdentificacion es de 10 caracteres")]
        public string NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        public string Email { get; set; }
    }
}
