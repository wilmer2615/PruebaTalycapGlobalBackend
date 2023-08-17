using System;

namespace Entities
{
    public class Envio
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
        public int CantidadProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public double PrecioEnvio { get; set; }
        public double Descuento { get; set; }
        public string NumeroGuia { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public EnvioMaritimo EnvioMaritimo { get; set; }
        public EnvioTerrestre EnvioTerrestre { get; set; }
    }
}
