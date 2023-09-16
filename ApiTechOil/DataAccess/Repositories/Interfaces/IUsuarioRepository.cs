using ApiTechOil.Entities;

namespace ApiTechOil.DataAccess.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario> { }
    public interface IProyectosRepository : IRepository<Proyectos> { }
    public interface IServiciosRepository : IRepository<Servicios> { }
    public interface ITrabajosRepository : IRepository<Trabajos> { }
}
