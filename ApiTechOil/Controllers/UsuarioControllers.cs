using ApiTechOil.DataAccess;
using Microsoft.AspNetCore.Mvc;
using ApiTechOil.Entities;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Authorization;
using ApiTechOil.DTOs;
using ApiTechOil.Infraestructure;

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
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, usuarios);
        }

        [HttpGet("{codUsuario}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUsuarioById(int codUsuario)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(codUsuario);
            if (usuario == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Usuario NO encontrado!"); // Devuelve un resultado NotFound si el proyecto no se encuentra.
            }
            return ResponseFactory.CreateSuccessResponse(200, usuario);
        }

        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Rergister")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _unitOfWork.UsuarioRepository.Insert(new Usuario(dto));
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
        }

        [Authorize(Policy = "Administrador")]
        [HttpPut("{CodUsuario}")]
        public async Task<IActionResult>Update([FromRoute] int CodUsuario, RegisterDto dto)
        {
            var result = await _unitOfWork.UsuarioRepository.Update(new Usuario(dto,CodUsuario));
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }

        /// <summary>
        ///  Elimina el usuario
        /// </summary>
        /// <returns>Eliminado o un 500</returns>
        [Authorize(Policy = "Administrador")]
        [HttpDelete("{codUsuario}")]
        public async Task<IActionResult> Delete([FromRoute] int codUsuario)
        {
            Usuario usuario = await _unitOfWork.UsuarioRepository.GetById(codUsuario);
            if (usuario == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Usuario NO encontrado!"); // Devuelve un resultado NotFound si el proyecto no se encuentra.
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
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }
        }
    }
}
