using ApiTechOil.DataAccess;
using Microsoft.AspNetCore.Mvc;
using ApiTechOil.Entities;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Authorization;
using ApiTechOil.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTechOil.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    [Authorize]
    public class UsuarioControllers : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioControllers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            return usuarios;
        }
        [HttpPost]
        [Route("Rergister")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Dni = dto.Dni,
                Email = dto.Email,
                Clave = dto.Clave,
                Activo = true,
                PerfilUsuario = 1
            };
            await _unitOfWork.UsuarioRepository.Insert(usuario);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        //// PUT api/<ValuesController>/5
        //[HttpPut("{codUsuario}"
        //public IActionResult Put (int codUsuario, Usuario UpdateUsuario)
        //{
        //    //var usuario = _usuarioRepository.GetUsuarioById(codUsuario);
        //    //if (usuario == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //usuario.Nombre = UpdateUsuario.Nombre;
        //    //usuario.Dni = UpdateUsuario.Dni;
        //    //usuario.PerfilUsuario = UpdateUsuario.PerfilUsuario;
        //    //usuario.Clave = UpdateUsuario.Clave;
        //    //_usuarioRepository.UpdateUsuario(usuario);
        //    return NoContent();
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{codUsuario}")]
        //public IActionResult Delete (int codUsuario)
        //{
        //    //var usuario = _usuarioRepository.GetUsuarioById(codUsuario);
        //    //if (usuario == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //_usuarioRepository.DeleteUsuario(codUsuario);
        //    return NoContent();
        //}
    }
}
