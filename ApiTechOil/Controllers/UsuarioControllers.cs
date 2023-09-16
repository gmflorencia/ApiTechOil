using ApiTechOil.DataAccess;
using Microsoft.AspNetCore.Mvc;
using ApiTechOil.Entities;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Authorization;
using ApiTechOil.DTOs;

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
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            return usuarios;
        }
        [HttpGet("{codUsuario}")]
        [AllowAnonymous]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int codUsuario)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(codUsuario);
            if (usuario == null)
            {
                return NotFound(); // Devuelve un resultado NotFound si el usuario no se encuentra.
            }
            return usuario;
        }

        [HttpPost]
        [Route("Rergister")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _unitOfWork.UsuarioRepository.Insert(new Usuario(dto));
            await _unitOfWork.Complete();
            return Ok(true);
        }
        [HttpPut("{CodUsuario}")]
        public async Task<IActionResult>Update([FromRoute] int CodUsuario, RegisterDto dto)
        {
            var result = await _unitOfWork.UsuarioRepository.Update(new Usuario(dto,CodUsuario));
            if (result) await _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpDelete("{codUsuario}")]

        public async Task<IActionResult> Delete([FromRoute] int codUsuario)
        {
            Usuario usuario = await _unitOfWork.UsuarioRepository.GetById(codUsuario);
            if (usuario == null)
            {
                return NotFound(); // Devuelve un resultado NotFound si el usuario no se encuentra.
            }
            var result = await _unitOfWork.UsuarioRepository.Update(new Usuario { 
                CodUsuario = codUsuario,
                Nombre = usuario.Nombre,
                Dni = usuario.Dni,
                Email = usuario.Email,
                Clave = usuario.Clave,
                PerfilUsuario = usuario.PerfilUsuario,
                Activo = false
            });
            if (result) await _unitOfWork.Complete();
            return Ok(result); 
        }
    }
}
