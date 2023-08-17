namespace Entities
{
    public class EnvioTerrestre 
    {
        public int Id { get; set; }
        public int IdEnvio { get; set; }
        public int IdBodega { get; set; }
        public string PlacaVehiculo { get; set; }
        public Envio Envio { get; set; }
        public Bodega Bodega { get; set; }
    }
}
