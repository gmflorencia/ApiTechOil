using ApiTechOil.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTechOil.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions <AppDbContext> options) : base(options)
        {
            fillUsuario();
        }
        public DbSet<Usuario> Usuarios { get; set; }
        private void fillUsuario()
        {
            if (Usuarios == null)
            {
                Usuarios.Add(new Usuario { CodUsuario = 1, Nombre = "Martin Cabrera", Dni = 31467581, PerfilUsuario = 1, Clave = "1234" });
                Usuarios.Add(new Usuario { CodUsuario = 2, Nombre = "Florencia Gonzalez", Dni = 37053098, PerfilUsuario = 2, Clave = "5678" });
                Usuarios.Add(new Usuario { CodUsuario = 3, Nombre = "Salome Cabrera", Dni = 58706438, PerfilUsuario = 1, Clave = "5792"});
                this.SaveChanges();
            }
        }
    }
}
