using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;

namespace WebAppl1.Pages
{
    public class AsignarMisionModel : PageModel
    {
        private readonly IMisionAstronautaRepository _misionAstronautaRepository;
        private readonly IAstronautaRepository _astronautaRepository;
        private readonly IMisionRepository _misionRepository;

        public AsignarMisionModel(IMisionAstronautaRepository misionAstronautaRepository, IAstronautaRepository astronautaRepository, IMisionRepository misionRepository)
        {
            _misionAstronautaRepository = misionAstronautaRepository;
            _astronautaRepository = astronautaRepository;
            _misionRepository = misionRepository;
        }

        public SelectList AstronautasSelect { get; set; } //listas que alimentan los dos dropdowns del modal.
                                                          //SelectList es un tipo especial de lista que Bootstrap y Razor usan para generar <select> automáticamente
        public SelectList MisionesSelect { get; set; }

        [BindProperty]                                 //valores que llegan del formulario cuando el usuario envía el modal.
                                                       //[BindProperty] le dice a Razor que mapee automáticamente lo que el usuario escribió/seleccionó a estas propiedades.
        public int AstronautaSeleccionado { get; set; }
        [BindProperty]
        public int MisionSeleccionada { get; set; }
        [BindProperty]
        public String Rol { get; set; }

        public List<Astronauta> Astronautas { get; set; } //lista de astronautas,
                                                          //se muestra en la tabla debajo del boton para que el usuario pueda ver quién está asignado a qué misión.

        

        public async Task OnGetAsync()
        {
            await CargarSelectsAsync();
        }

        //Crea un objeto nuevo de tipo MisionAstronauta con los datos que llegaron del formulario
        public async Task<IActionResult> OnPostAsync()
        {
            // verifica si ya existe esa combinación
            var existe = await _misionAstronautaRepository.ExistsAsync(AstronautaSeleccionado, MisionSeleccionada);

            if (existe)
            {
                ModelState.AddModelError(string.Empty,
                    "Este astronauta ya está asignado a esa misión.");
                await CargarSelectsAsync();
                return Page();
            }

            var relacion = new MisionAstronauta
            {
                AstronautaID = AstronautaSeleccionado,
                MisionID = MisionSeleccionada,
                Rol = Rol
            };

            
            await _misionAstronautaRepository.CreateAsync(relacion); //guarda la nueva relación en la base de datos a través del repositorio
            return RedirectToPage();
        }

        private async Task CargarSelectsAsync()
        {
            AstronautasSelect = new SelectList(          //llenamos el dropdown de astronautas con todos los astronautas disponibles en la base de datos.
                await _astronautaRepository.GetAllAsync(),
                "AstronautaId", "Nombre"                 //"AstronautaId" es el valor que se guarda y "Nombre" es lo que ve el usuario.
            );

            MisionesSelect = new SelectList(
                await _misionRepository.GetAllAsync(),
                //.Where(m => m.Estado != "Completada") //solo mostrar misiones que no estén completadas,
                //para evitar asignar astronautas a misiones que ya terminaron.
                "MisionId", "Nombre"
            );

            Astronautas = await _astronautaRepository.GetAllWithMissionsAsync(); //llenamos la lista de astronautas con sus misiones asignadas para mostrarla en la tabla debajo del botón.
        }
    }
}
