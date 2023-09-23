using ApiTechOil.DataAccess;
using Microsoft.AspNetCore.Mvc;
using ApiTechOil.Entities;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Authorization;
using ApiTechOil.DTOs;
using ApiTechOil.Infraestructure;
using ApiTechOil.Helpers;

namespace ApiTechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///  Devuelve todo los Usuarios
        /// </summary>
        /// <returns>retorna un statusCode 200 todos los Usuarios</returns>

        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

            var paginadoUsuarios = PaginateHelper.Paginate(usuarios, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginadoUsuarios);

        }

        /// <summary>
        ///  Devuelve un Usuario
        /// </summary>
        /// <returns>retorna un statusCode 200 Usuario</returns>

        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet("{codUsuario}")]
        public async Task<IActionResult> GetUsuarioById(int codUsuario)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(codUsuario);
            if (usuario == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Usuario NO encontrado!"); 
            }
            return ResponseFactory.CreateSuccessResponse(200, usuario);
        }

        /// <summary>
        ///  Registra un nuevo Usuario
        /// </summary>
        /// <returns>retorna Usuario registrado con un statusCode 200</returns>

        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Rergister")]
        public async Task<IActionResult> Register(UsuarioDto dto)
        {
            await _unitOfWork.UsuarioRepository.Insert(new Usuario(dto));
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
        }

        /// <summary>
        ///  Actualiza un Usuario
        /// </summary>
        /// <returns>retorna un Usuario actualizado o un statusCode 201</returns>

        [Authorize(Policy = "Administrador")]
        [HttpPut("{CodUsuario}")]
        public async Task<IActionResult>Update([FromRoute] int CodUsuario, UsuarioDto dto)
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
        ///  Elimina un Usuario
        /// </summary>
        /// <returns> retorna Usuario eliminado o un 500</returns>
        
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
                CodRol = usuario.CodRol,
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
