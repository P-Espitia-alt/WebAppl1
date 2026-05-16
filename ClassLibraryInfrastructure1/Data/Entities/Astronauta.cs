using System.ComponentModel.DataAnnotations;

namespace ClassLibraryInfrastructure1.Data.Entities
{
    public class Astronauta
    {
        public Astronauta()
        {
        }

        public int AstronautaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "The Pais field is required.")]
        public int? PaisId { get; set; }
        public Pais? Pais { get; set; } //Propiedad de navegación:relación entre clases, permiten acceder al objeto completo
                                        //relacionado con la entidad actual, en este caso, el país al que pertenece el astronauta.
        public int TotalMisiones { get; set; }

        public List<MisionAstronauta>? MisionesAsignadas { get; set; } //Propiedad de navegación:relación entre clases, permiten acceder al objeto completo
                                                                       //relacionado con la entidad actual, en este caso, las misiones en las que ha participado el astronauta.

    }
}
