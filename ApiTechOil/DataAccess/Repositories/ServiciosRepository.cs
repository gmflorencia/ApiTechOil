using Microsoft.EntityFrameworkCore;
using ApiTechOil.Entities;
using ApiTechOil.DataAccess.Repositories.Interfaces;

namespace ApiTechOil.DataAccess.Repositories
{
    public class ServiciosRepository : Repository<Servicios> , IServiciosRepository 
    {

        public ServiciosRepository(AppDbContext context) : base(context) { }

        public override async Task<bool> Update(Servicios updateServicio)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.CodServicio == updateServicio.CodServicio);
            if (servicio == null) { return false; }
            servicio.Descr = updateServicio.Descr;
            servicio.Estado = updateServicio.Estado;
            servicio.ValorHora = updateServicio.ValorHora;

            _context.Servicios.Update(servicio);
            return true;
        }
        public virtual async Task<List<Servicios>> GetByEstado(bool estado)
        {
            return await _context.Servicios.Where(e => e.Estado == estado).ToListAsync();
        }
    }
}
