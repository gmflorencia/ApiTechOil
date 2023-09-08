using Microsoft.EntityFrameworkCore;

namespace TechOilAPI.DataAccess.DataBaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDataBase(ModelBuilder modelBuilder);
    }
}
