using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Data.Entities;

namespace WebAppl1.Pages
{
    public class MisionModel : PageModel
    {
        private readonly AppDbContext _context;
        public MisionModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Mision> MisionesList { get; set; } = new();
        public async Task OnGetAsync()
        {
            MisionesList = await _context.Mision
                .Where(m => m.Estado == "Completada")
                .ToListAsync();

        }
    }
}
