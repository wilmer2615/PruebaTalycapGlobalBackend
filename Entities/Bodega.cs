using System.Collections.Generic;

namespace Entities
{
    public class Bodega
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<EnvioTerrestre> EnviosTerrestres { get; set; }

    }
}
