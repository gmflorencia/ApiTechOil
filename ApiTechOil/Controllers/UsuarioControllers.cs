using ApiTechOil.DataAccess;
using ApiTechOil.Repository;
using Microsoft.AspNetCore.Mvc;
using ApiTechOil.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTechOil.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioControllers : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioControllers(IUsuarioRepository UsuarioRepository)
        {
            _usuarioRepository = UsuarioRepository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioRepository.GetAllUsuarios();
            return Ok(usuarios);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{codUsuario}")]
        public IActionResult Get (int codUsuario)
        {
            var usuario = _usuarioRepository.GetUsuarioById(codUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        
        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post (Usuario usuario)
        {
            _usuarioRepository.AddUsuario(usuario);
            return CreatedAtAction(nameof(Get), new { codUsuario = usuario.CodUsuario }, usuario);
        }
        
        // PUT api/<ValuesController>/5
        [HttpPut("{codUsuario}")]
        public IActionResult Put (int codUsuario, Usuario UpdateUsuario)
        {
            var usuario = _usuarioRepository.GetUsuarioById(codUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Nombre = UpdateUsuario.Nombre;
            usuario.Dni = UpdateUsuario.Dni;
            usuario.PerfilUsuario = UpdateUsuario.PerfilUsuario;
            usuario.Clave = UpdateUsuario.Clave;
            _usuarioRepository.UpdateUsuario(usuario);
            return NoContent();
        }
        
        // DELETE api/<ValuesController>/5
        [HttpDelete("{codUsuario}")]
        public IActionResult Delete (int codUsuario)
        {
            var usuario = _usuarioRepository.GetUsuarioById(codUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            _usuarioRepository.DeleteUsuario(codUsuario);
            return NoContent();
        }
    }
}
