using ApiTechOil.Entities;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTechOil.DataAccess.Repositories
{
    public class PerfilUsuarioRepository : Repository<PerfilUsuario>, IPerfilUsuarioRepository
    {

        public PerfilUsuarioRepository(AppDbContext context) : base(context)
        {
        }
        public override async Task<bool> Update(PerfilUsuario updatePerfilUsuario)
        {
            var perfilUsuario = await _context.PerfilUsuarios.FirstOrDefaultAsync(x => x.Id == updatePerfilUsuario.Id);
            if (perfilUsuario == null) { return false; }

            perfilUsuario.Descripcion = updatePerfilUsuario.Descripcion;
            perfilUsuario.Activo = updatePerfilUsuario.Activo;

            _context.PerfilUsuarios.Update(perfilUsuario);
            return true;
        }
    }
}

