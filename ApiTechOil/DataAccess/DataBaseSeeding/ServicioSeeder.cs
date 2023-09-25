using ApiTechOil.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTechOil.DataAccess.DataBaseSeeding
{
    public class ServicioSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>().HasData(
                    new Servicio
                    {
                        CodServicio = 1,
                        Descr = "Gasoducto",
                        Estado = true,
                        ValorHora = 200,
                    },
                    new Servicio
                    {
                        CodServicio = 2,
                        Descr = "Acueducto",
                        Estado = false,
                        ValorHora = 200,
                    },
                    new Servicio
                    {
                        CodServicio = 3,
                        Descr = "Gas Natural",
                        Estado = true,
                        ValorHora = 200,
                    });
        }
    }
}
