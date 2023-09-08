using TechOilAPI.DataAccess.DataBaseSeeding;
using TechOilAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace TechOilAPI.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions <AppDbContext> options) : base(options) 
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Trabajos> Trabajos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            var seeders = new List<IEntitySeeder>
            {
                new EntitySeeder()
            };
            foreach (var seeder in seeders)
            {
                seeder.SeedDataBase(modelBuilder);
            }
        }
    }
}
