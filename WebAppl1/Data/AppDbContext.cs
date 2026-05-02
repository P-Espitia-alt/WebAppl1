using Microsoft.EntityFrameworkCore;
using WebAppl1.Data.Entities;
using WebAppl1.Pages;

namespace WebAppl1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Agrega tus DbSets aquí
        public DbSet<Astronauta> Astronauta { get; set; }
        public DbSet<Mision> Mision { get; set; }
        public DbSet<Pais> Pais { get; set; }
    }
}
