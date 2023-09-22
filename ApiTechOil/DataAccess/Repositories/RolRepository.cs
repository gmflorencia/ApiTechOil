using ApiTechOil.Entities;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTechOil.DataAccess.Repositories
{
    public class RolRepository : Repository<Rol>, IRolRepository
    {

        public RolRepository(AppDbContext context) : base(context)
        {
        }
        public override async Task<bool> Update(Rol updateRol)
        {
            var rol = await _context.Roles.FirstOrDefaultAsync(x => x.CodRol == updateRol.CodRol);
            if (rol == null) { return false; }

            rol.Descripcion = updateRol.Descripcion;
            rol.Activo = updateRol.Activo;

            _context.Roles.Update(rol);
            return true;
        }
    }
}

