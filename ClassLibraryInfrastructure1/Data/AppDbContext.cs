using Microsoft.EntityFrameworkCore;
using ClassLibraryInfrastructure1.Data.Entities;

namespace ClassLibraryInfrastructure1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Agrega tus DbSets aquí
        public DbSet<Astronauta> Astronauta { get; set; }
        public DbSet<Mision> Mision { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<MisionAstronauta> MisionAstronauta { get; set; }
    }
}
