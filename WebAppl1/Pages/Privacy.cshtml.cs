using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Data.Entities;

namespace WebAppl1.Pages
{
    public class PrivacyModel : PageModel
    {

        private readonly AppDbContext _context;

        public PrivacyModel(AppDbContext context)
        {
            _context = context;

        }

        public List<Astronauta> Astronautas { get; set; } = new();

        public async Task OnGet()
        {
            Astronautas = await _context.Astronauta.ToListAsync();
        }
    }

}
