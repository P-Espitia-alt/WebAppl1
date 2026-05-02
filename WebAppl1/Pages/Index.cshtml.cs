using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppl1.Data;
using WebAppl1.Data.Entities;

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

        public async Task OnGetAsync()
        {
            PaisesSelect = new SelectList(
                await _context.Pais.ToListAsync(), 
                "PaisId", "Nombre"
                );
        }

        public async Task<IActionResult> OnPostAsync()
        {
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
            return RedirectToPage("/Mision");
        }

       
    }
}
