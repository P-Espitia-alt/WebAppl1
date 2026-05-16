using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;

namespace WebAppl1.Pages
{
    public class AgregarAstronautaModel : PageModel
    {

        private readonly IPaisRepository _paisRepository;
        private readonly IAstronautaRepository _astronautaRepository;

        public AgregarAstronautaModel(IPaisRepository paisRepository, IAstronautaRepository astronautaRepository)
        {
            _paisRepository = paisRepository;
            _astronautaRepository = astronautaRepository;
        }

        [BindProperty]
        public Astronauta Astronauta { get; set; } = new();
        public SelectList PaisesSelect { get; set; }
        public DateTime FechaMaxima { get; set; } //para la edad

        public async Task OnGetAsync()
        {
            PaisesSelect = new SelectList(
                await _paisRepository.GetAllAsync(), 
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
                    await _paisRepository.GetAllAsync(),
                    "PaisId", "Nombre"
                    );
                return Page();
            }
            
            await _astronautaRepository.CreateAsync(Astronauta);
            return RedirectToPage("/Astronautas");
        }
    }
}
