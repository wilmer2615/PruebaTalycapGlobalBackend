using System.Collections.Generic;

namespace Entities
{
    public class Puerto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public List<EnvioMaritimo> EnviosMaritimos { get; set; }

    }
}
