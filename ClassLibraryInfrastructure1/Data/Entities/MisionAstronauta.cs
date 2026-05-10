using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryInfrastructure1.Data.Entities
{
    public class MisionAstronauta
    {
        public int MisionAstronautaID { get; set; }
        public int MisionID { get; set; }
        public int AstronautaID { get; set; }
        public String Rol { get; set; }
        //Propiedades de navegación
        public Mision? Mision { get; set; }
        public Astronauta? Astronauta { get; set; }
    }
}
