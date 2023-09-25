using ApiTechOil.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTechOil.DataAccess.DataBaseSeeding
{
    public class TrabajoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajo>().HasData(
                    new Trabajo
                    {
                        CodTrabajo = 1,
                        Fecha = DateTime.Now,
                        CodProyecto = 1,
                        CodServicio = 2,
                        CantHoras = 28,
                        ValorHora = 0.25,
                        Costo = 150.000,
                        Activo = true
                    },
                    new Trabajo
                    {
                        CodTrabajo = 2,
                        Fecha = DateTime.Now,
                        CodProyecto = 2,
                        CodServicio = 3,
                        CantHoras = 28,
                        ValorHora = 0.25,
                        Costo = 180.000,
                        Activo = true

                    },
                    new Trabajo
                    {
                        CodTrabajo = 3,
                        Fecha = DateTime.Now,
                        CodProyecto = 3,
                        CodServicio = 3,
                        CantHoras = 28,
                        ValorHora = 0.25,
                        Costo = 190.000,
                        Activo = true

                    });
        }
    }
}
