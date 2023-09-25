using ApiTechOil.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTechOil.DataAccess.DataBaseSeeding
{
    public class ProyectoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>().HasData(
                    new Proyecto
                    {
                        CodProyecto = 1,
                        Nombre = "Tinogasta",
                        Direccion = "Lavalle 1674 CABA",
                        Estado = 1,
                        Activo = true

                    },
                    new Proyecto
                    {
                        CodProyecto = 2,
                        Nombre = "Vaca Muerta",
                        Direccion = "Lavalle 178 Lanus",
                        Estado = 2,
                        Activo = true
                    },
                    new Proyecto
                    {
                        CodProyecto = 3,
                        Nombre = "Pucará",
                        Direccion = "Maldonado 254 Monte Grande",
                        Estado = 3,
                        Activo = true
                    });
        }
    }
}
