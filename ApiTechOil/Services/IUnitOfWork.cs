using ApiTechOil.DataAccess.Repositories;

namespace ApiTechOil.Services
{
    public interface IUnitOfWork
    {
        public UsuarioRepository UsuarioRepository { get; }
    }
}
