using ApiTechOil.DataAccess.DataBaseSeeding;
using ApiTechOil.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTechOil.DataAccess
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
