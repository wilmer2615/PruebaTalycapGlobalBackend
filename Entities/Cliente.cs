using System.Collections.Generic;

namespace Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Email { get; set; }
        public List<Envio> Envios { get; set; }
    }
}
