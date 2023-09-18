using ApiTechOil.DataAccess;
using ApiTechOil.DataAccess.Repositories;

namespace ApiTechOil.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ProyectosRepository ProyectosRepository { get; set; }
        public ServiciosRepository ServiciosRepository { get; set; }
        public TrabajosRepository TrabajosRepository { get; set; }
        public PerfilUsuarioRepository PerfilUsuarioRepository { get; }
        public UsuarioRepository UsuarioRepository { get; set; }

        public UnitOfWorkService(AppDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
            ProyectosRepository = new ProyectosRepository(_context);
            ServiciosRepository = new ServiciosRepository(_context);
            TrabajosRepository = new TrabajosRepository(_context);  
            PerfilUsuarioRepository = new PerfilUsuarioRepository(_context);
        }
        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
    }
}
