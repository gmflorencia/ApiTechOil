using Microsoft.EntityFrameworkCore;
using ApiTechOil.Entities;
using ApiTechOil.DataAccess.Repositories.Interfaces;

namespace ApiTechOil.DataAccess.Repositories
{
    public class TrabajosRepository : Repository<Trabajos> , ITrabajosRepository 
    {

        public TrabajosRepository(AppDbContext context) : base(context) { }
        public override async Task<bool> Update(Trabajos updateTrabajo)
        {
            var trabajo = await _context.Trabajos.FirstOrDefaultAsync(x=> x.CodTrabajo == updateTrabajo.CodTrabajo);
            if (trabajo == null) { return false; }
            trabajo.Fecha = updateTrabajo.Fecha;
            trabajo.CodProyecto = updateTrabajo.CodProyecto;
            trabajo.CodServicio = updateTrabajo.CodServicio;
            trabajo.CantHoras = updateTrabajo.CantHoras;
            trabajo.Costo = updateTrabajo.Costo;
            trabajo.Activo = updateTrabajo.Activo;
            
            _context.Trabajos.Update(trabajo);
            return true;
        }
    }
}
