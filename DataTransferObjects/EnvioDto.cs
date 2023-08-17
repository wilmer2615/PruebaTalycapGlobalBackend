using System;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class EnvioDto
    {
        [Required(ErrorMessage = "El Id del producto es requerido")]
        public int IdProducto { get; set; }
        public int IdBodega { get; set; }
        public int IdPuerto { get; set; }

        [Required(ErrorMessage = "La cantidad del producto es requerida")]
        public int CantidadProducto { get; set; }       

        [Required(ErrorMessage = "La fecha de entrega es requerida")]
        public DateTime FechaEntrega { get; set; }

        [Required(ErrorMessage = "El precio de envio es requerido")]
        public double PrecioEnvio { get; set; }
        public double Descuento { get; set; }

        [Required(ErrorMessage = "El numero de guia es requerido")]
        public string NumeroGuia { get; set; }

        [Required(ErrorMessage = "El Id del cliente es requerido")]
        public int IdCliente { get; set; }
        public bool Maritimo { get; set; }
        public bool Terrestre { get; set; }
        public string PlacaVehiculo { get; set; }
        public string numeroFlota { get; set; }



    }
}
