using ApiTechOil.DataAccess.Repositories;
using ApiTechOil.DataAccess.Repositories.Interfaces;

namespace ApiTechOil.Services
{
    public interface IUnitOfWork
    {
        public ProyectosRepository ProyectosRepository { get; }
        public ServiciosRepository ServiciosRepository { get; }
        public TrabajosRepository TrabajosRepository { get; }
        public UsuarioRepository UsuarioRepository { get; }
        public PerfilUsuarioRepository PerfilUsuarioRepository { get; }
        Task<int> Complete();
    }
    
}
