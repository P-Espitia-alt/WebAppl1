using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;

namespace WebAppl1.Pages
{
    public class AstronautasModel : PageModel
    {

        private readonly IAstronautaRepository _astronautaRepository;

        public AstronautasModel(IAstronautaRepository astronautaRepository)
        {
            _astronautaRepository = astronautaRepository;
        }

        public List<Astronauta> Astronautas { get; set; } = new();

        public async Task OnGet()
        {
            Astronautas = await _astronautaRepository.GetAllAsync();
        }
    }
}
