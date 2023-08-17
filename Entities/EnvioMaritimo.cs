namespace Entities
{
    public class EnvioMaritimo
    {
        public int Id { get; set; }
        public int IdEnvio { get; set; }
        public int IdPuerto { get; set; }
        public string NumeroFlota { get; set; }
        public Envio Envio { get; set; }
        public Puerto Puerto { get; set; }
    }
}
