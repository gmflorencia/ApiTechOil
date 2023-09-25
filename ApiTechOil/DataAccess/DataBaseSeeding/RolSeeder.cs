using ApiTechOil.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTechOil.DataAccess.DataBaseSeeding
{
    public class RolSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    CodRol = 1,
                    Descripcion = "Administrador",
                    Activo = true,
                },
                new Rol
                {
                    CodRol = 2,
                    Descripcion = "Consultor",
                    Activo = true,
                });
        }
    }
}
