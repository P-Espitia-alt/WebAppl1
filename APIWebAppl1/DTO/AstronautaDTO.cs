namespace APIWebAppl1.DTO
{
    public class AstronautaDTO
    {

        public int AstronautaId { get; set; }

        public string Usuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int? PaisId { get; set; }

        public int TotalMisiones { get; set; }

    }
}
