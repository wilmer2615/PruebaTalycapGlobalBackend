using System.Collections.Generic;

namespace Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string TipoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public List<Envio> Envios { get; set; }

    }
}
