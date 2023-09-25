using ApiTechOil.DataAccess;
using ApiTechOil.DataAccess.Repositories;

namespace ApiTechOil.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ProyectoRepository ProyectoRepository { get; set; }
        public ServicioRepository ServicioRepository { get; set; }
        public TrabajoRepository TrabajoRepository { get; set; }
        public RolRepository RolRepository { get; }
        public UsuarioRepository UsuarioRepository { get; set; }

        public UnitOfWorkService(AppDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
            ProyectoRepository = new ProyectoRepository(_context);
            ServicioRepository = new ServicioRepository(_context);
            TrabajoRepository = new TrabajoRepository(_context);  
            RolRepository = new RolRepository(_context);
        }
        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
    }
}
