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

        //para el trigger que actualiza el total de misiones de cada astronauta, le decimos a EF que la tabla MisionAstronauta tiene un trigger llamado "trg_UpdateTotalMisiones"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MisionAstronauta>()
                .ToTable(tb => tb.HasTrigger("trg_UpdateTotalMisiones"));

            modelBuilder.Entity<MisionAstronauta>()
                .Property(m => m.MisionAstronautaID)
                .ValueGeneratedOnAdd();
        }
    }
}
