using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Data.Entities;

namespace WebAppl1.Pages
{
    public class IndexModel : PageModel
    {

        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Astronauta Astronauta { get; set; } = new();
        public SelectList PaisesSelect { get; set; }
        public DateTime FechaMaxima { get; set; } //para la edad

        public async Task OnGetAsync()
        {
            PaisesSelect = new SelectList(
                await _context.Pais.ToListAsync(), 
                "PaisId", "Nombre"
            );

            Astronauta.FechaNacimiento = DateTime.Today;
            FechaMaxima = DateTime.Today.AddYears(-18);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Astronauta.FechaNacimiento == DateTime.MinValue ||
                Astronauta.FechaNacimiento > DateTime.Today.AddYears(-18))
            {
                ModelState.AddModelError("Astronauta.FechaNacimiento",
                    "El astronauta debe tener al menos 18 años");
            }
            if (!ModelState.IsValid)
            {
                PaisesSelect = new SelectList(
                    await _context.Pais.ToListAsync(),
                    "PaisId", "Nombre"
                    );
                return Page();
            }
            
            _context.Astronauta.Add(Astronauta);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Privacy");
        }


    }
}
