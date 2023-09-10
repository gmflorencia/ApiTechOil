using ApiTechOil.DataAccess;
using ApiTechOil.DataAccess.Repositories;

namespace ApiTechOil.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UsuarioRepository UsuarioRepository { get; private set; }

        public UnitOfWorkService(AppDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
        }
    }
}
