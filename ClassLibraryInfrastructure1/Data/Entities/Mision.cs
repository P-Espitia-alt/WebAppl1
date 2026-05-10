namespace ClassLibraryInfrastructure1.Data.Entities
{
    public class Mision
    {
        public int MisionId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public DateTime? FechaRetorno { get; set; }
        public string Vehiculo { get; set; }
        public string Estado { get; set; }

    }
}
