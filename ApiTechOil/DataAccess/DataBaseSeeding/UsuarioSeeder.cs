using ApiTechOil.Entities;
using ApiTechOil.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ApiTechOil.DataAccess.DataBaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    CodUsuario = 1,
                    Nombre = "Martin Cabrera",
                    Dni = 31467581,
                    CodRol = 1,
                    Email = "martin@gmail.com",
                    Clave = ClaveEncryptHelper.EncryptClave("1234", "martin@gmail.com"),
                    Activo = true

                },
                new Usuario
                {
                    CodUsuario = 2,
                    Nombre = "Florencia Gonzalez",
                    Dni = 37053098,
                    CodRol = 2,
                    Email = "florencia@gmail.com",
                    Clave = ClaveEncryptHelper.EncryptClave("5678", "florencia@gmail.com"),
                    Activo = true
                },
                new Usuario
                {
                    CodUsuario = 3,
                    Nombre = "Salome Cabrera",
                    Dni = 58706438,
                    CodRol = 1,
                    Email = "salome@gmail.com",
                    Clave = ClaveEncryptHelper.EncryptClave("5792", "salome@gmail.com"),
                    Activo = true

                });
        }
    }
}
