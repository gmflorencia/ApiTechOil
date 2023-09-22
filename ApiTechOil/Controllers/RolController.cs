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
    public class RolController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RolController(IUnitOfWork unitOfWork)
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
            var rol = await _unitOfWork.RolRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, rol);
        }

        /// <summary>
        ///  Devuelve un Rol
        /// </summary>
        /// <returns>retorna un statusCode 200 un Rol</returns>

        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rol = await _unitOfWork.RolRepository.GetById(id);
            if (rol == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Perfil NO encontrado!");
            }
            return ResponseFactory.CreateSuccessResponse(200, rol);
        }

        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("rol")]
        public async Task<IActionResult> Insert(RolDto dto)
        {

            var rol = new Rol(dto);
            await _unitOfWork.RolRepository.Insert(rol);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Perfil registrado con exito!");

        }

        [Authorize(Policy = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, RolDto dto)
        {
            var result = await _unitOfWork.RolRepository.Update(new Rol(dto, id));

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
            Rol rol = await _unitOfWork.RolRepository.GetById(id);
            if (rol == null)
            {
                return NotFound(); // Devuelve un resultado NotFound si el usuario no se encuentra.
            }
            var result = await _unitOfWork.RolRepository.Update(new Rol
            {
                CodRol = id,
                Descripcion = rol.Descripcion,
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
