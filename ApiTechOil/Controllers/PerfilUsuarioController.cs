using ApiTechOil.DTOs;
using ApiTechOil.Entities;
using ApiTechOil.Infraestructure;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ApiTechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilUsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PerfilUsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///  Devuelve todos los Roles
        /// </summary>
        /// <returns>retorna un statusCode 200 todos los Roles</returns>

        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var PerfilUsuario = await _unitOfWork.PerfilUsuarioRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, PerfilUsuario);
        }

        /// <summary>
        ///  Devuelve un Rol
        /// </summary>
        /// <returns>retorna un statusCode 200 un Rol</returns>

        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var perfilUsuario = await _unitOfWork.PerfilUsuarioRepository.GetById(id);
            if (perfilUsuario == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Perfil NO encontrado!");
            }
            return ResponseFactory.CreateSuccessResponse(200, perfilUsuario);
        }

        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("PerfilUsuario")]
        public async Task<IActionResult> Insert(PerfilUsuarioDto dto)
        {

            var perfilUsuario = new PerfilUsuario(dto);
            await _unitOfWork.PerfilUsuarioRepository.Insert(perfilUsuario);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Perfil registrado con exito!");

        }

        [Authorize(Policy = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, PerfilUsuarioDto dto)
        {
            var result = await _unitOfWork.PerfilUsuarioRepository.Update(new PerfilUsuario(dto, id));

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el perfil");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }

        [Authorize(Policy = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            PerfilUsuario perfilUsuario = await _unitOfWork.PerfilUsuarioRepository.GetById(id);
            if (perfilUsuario == null)
            {
                return NotFound(); // Devuelve un resultado NotFound si el usuario no se encuentra.
            }
            var result = await _unitOfWork.PerfilUsuarioRepository.Update(new PerfilUsuario
            {
                Id = id,
                Descripcion = perfilUsuario.Descripcion,
                Activo = false
            });
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el perfil");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }
        }
    }
}
