using TechOilAPI.Entities;

namespace TechOilAPI.Repository
{
    public interface IUsuarioRepository{
         IEnumerable<Usuario>GetAllUsuarios();
         Usuario GetUsuarioById(int id);
         void AddUsuario(Usuario usuario);
         void UpdateUsuario(Usuario usuario);
         void DeleteUsuario(int id);
    }
}
