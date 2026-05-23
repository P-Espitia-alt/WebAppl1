using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;

namespace WebAppl1.Pages
{
    public class MisionModel : PageModel
    {
        private readonly IMisionRepository _misionRepository;

        public MisionModel(IMisionRepository misionRepository)
        {
            _misionRepository = misionRepository;
        }

        public List<Mision> MisionesList { get; set; } = new();
        public async Task OnGet()
        {
           
            MisionesList = await _misionRepository.GetAllAsync();
        }
    }
}
