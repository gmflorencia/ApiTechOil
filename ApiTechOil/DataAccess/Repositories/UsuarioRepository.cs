using Microsoft.EntityFrameworkCore;
using ApiTechOil.DataAccess;
using ApiTechOil.Entities;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using ApiTechOil.DTOs;
using ApiTechOil.Helpers;

namespace ApiTechOil.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario> , IUsuarioRepository 
    {

        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.Include(x => x.Roles).SingleOrDefaultAsync(x => x.Email == dto.Email && x.Clave == ClaveEncryptHelper.EncryptClave(dto.Clave, dto.Email));
        }
        public override async Task<bool> Update(Usuario updateUsuario)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x=> x.CodUsuario == updateUsuario.CodUsuario);
            if (usuario == null) { return false; }
            usuario.Nombre = updateUsuario.Nombre;
            usuario.Email = updateUsuario.Email;
            usuario.Clave = updateUsuario.Clave;
            usuario.Activo = updateUsuario.Activo;
            usuario.CodRol = updateUsuario.CodRol;

            _context.Usuarios.Update(usuario);
            return true;
        }
        public override async Task<bool> Delete(int id)
        {
            var usuario = await _context.Usuarios.Where(x => x.CodUsuario == id).FirstOrDefaultAsync();
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            return true;
        }
    }
}
