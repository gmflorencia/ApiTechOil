using Microsoft.EntityFrameworkCore;
using ApiTechOil.DataAccess;
using ApiTechOil.Entities;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using ApiTechOil.DTOs;

namespace ApiTechOil.DataAccess.Repositories
{
    public class ProyectosRepository : Repository<Proyectos> , IProyectosRepository 
    {

        public ProyectosRepository(AppDbContext context) : base(context) { }
        public override async Task<bool> Update(Proyectos updateProyecto)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x=> x.CodProyecto == updateProyecto.CodProyecto);
            if (proyecto == null) { return false; }
            proyecto.Nombre = updateProyecto.Nombre;
            proyecto.Direccion = updateProyecto.Direccion;
            proyecto.Estado = updateProyecto.Estado;
            proyecto.Activo = updateProyecto.Activo;

            _context.Proyectos.Update(proyecto);
            return true;
        }
        public override async Task<bool> Delete(int id)
        {
            var proyecto = await _context.Proyectos.Where(x => x.CodProyecto == id).FirstOrDefaultAsync();
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
            }
            return true;
        }
        public virtual async Task<List<Proyectos>> GetByEstado(int estado)
        {
            return await _context.Proyectos.Where(e => e.Estado == estado).ToListAsync();
        }
    }
}
