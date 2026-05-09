using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Data.Entities;

namespace WebAppl1.Pages
{
    public class AsignarMisionModel : PageModel
    {

        private readonly AppDbContext _context;

        public AsignarMisionModel(AppDbContext context)
        {
            _context = context;
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
            AstronautasSelect = new SelectList(          //llenamos el dropdown de astronautas con todos los astronautas disponibles en la base de datos.
                await _context.Astronauta.ToListAsync(), 
                "AstronautaId", "Nombre"                 //"AstronautaId" es el valor que se guarda y "Nombre" es lo que ve el usuario.
            );
            
            MisionesSelect = new SelectList(
                await _context.Mision
                //.Where(m => m.Estado != "Completada") //solo mostrar misiones que no estén completadas,
                                                        //para evitar asignar astronautas a misiones que ya terminaron.
                .ToListAsync(), 
                "MisionId", "Nombre"
            );

            Astronautas = await _context.Astronauta
                .Include(a => a.MisionesAsignadas) //Include: trae las relaciones MisionAstronauta de cada astronauta
                .ThenInclude(ma => ma.Mision)      //ThenInclude: dentro de cada relación, trae la Mision completa
                .ToListAsync();
        }

        //Crea un objeto nuevo de tipo MisionAstronauta con los datos que llegaron del formulario
        public async Task<IActionResult> OnPostAsync()
        {
            var relacion = new MisionAstronauta
            {
                AstronautaID = AstronautaSeleccionado,
                MisionID = MisionSeleccionada,
                Rol = Rol
            };

            _context.MisionAstronauta.Add(relacion);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

    }
}
