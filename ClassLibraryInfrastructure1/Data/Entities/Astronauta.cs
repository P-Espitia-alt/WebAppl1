namespace ClassLibraryInfrastructure1.Data.Entities
{
    public class Astronauta
    {
        public int AstronautaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int PaisId { get; set; }
        public int TotalMisiones { get; set; }

    }
}
