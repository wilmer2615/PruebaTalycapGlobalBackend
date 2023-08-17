using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class EnvioMaritimoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Id del envio es requerido")]
        public int IdEnvio { get; set; }

        [Required(ErrorMessage = "El Id del puerto es requerido")]
        public int IdPuerto { get; set; }

        [Required(ErrorMessage = "El numero de flota es requerido")]
        public string NumeroFlota { get; set; }
    }
}
