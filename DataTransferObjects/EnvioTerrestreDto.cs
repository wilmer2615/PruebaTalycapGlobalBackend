using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class EnvioTerrestreDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Id del envio es requerido")]
        public int IdEnvio { get; set; }

        [Required(ErrorMessage = "El Id de la bodega es requerido")]
        public int IdBodega { get; set; }

        [Required(ErrorMessage = "El numero de placa es requerida")]
        public string PlacaVehiculo { get; set; }
    }
}
