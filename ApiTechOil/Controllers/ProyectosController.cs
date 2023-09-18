using ApiTechOil.Services;
using Microsoft.AspNetCore.Mvc;
using ApiTechOil.Entities;
using ApiTechOil.DTOs;
using Microsoft.AspNetCore.Authorization;
using ApiTechOil.Infraestructure;

namespace ApiTechOil.Controllers
{
    [Route("api/Proyecto")]
    [ApiController]
    [Authorize]
    public class ProyectosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProyectosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var proyectos = await _unitOfWork.ProyectosRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, proyectos);
        }

        [HttpGet("{codProyecto}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProyectoById(int codProyecto)
        {
            var proyecto = await _unitOfWork.ProyectosRepository.GetById(codProyecto);
            if (proyecto == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Proyecto NO encontrado!"); // Devuelve un resultado NotFound si el proyecto no se encuentra.
            }
            return ResponseFactory.CreateSuccessResponse(200, proyecto);
        }

        [HttpGet]
        [Route("/api/Proyecto/estado/{estado}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByEstado(int estado)
        {
            var proyectos = await _unitOfWork.ProyectosRepository.GetByEstado(estado);
            if (!proyectos.Any())
            {
                return ResponseFactory.CreateSuccessResponse(404, "NO existe estado o no hay proyecto con este estado!");
            }
            return ResponseFactory.CreateSuccessResponse(200, proyectos);
        }

        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ProyectosDto dto)
        {
            await _unitOfWork.ProyectosRepository.Insert(new Proyectos(dto));
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Proyecto registrado con exito!");
        }

        [Authorize(Policy = "Administrador")]
        [HttpPut("{codProyecto}")]
        public async Task<IActionResult> Update([FromRoute] int codProyecto, ProyectosDto dto)
        {
            var result = await _unitOfWork.ProyectosRepository.Update(new Proyectos(dto, codProyecto));

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el proyecto");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }

        [Authorize(Policy = "Administrador")]
        [HttpDelete("{codProyecto}")]
        public async Task<IActionResult> Delete([FromRoute] int codProyecto)
        {
            Proyectos proyecto = await _unitOfWork.ProyectosRepository.GetById(codProyecto);
            if (proyecto == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Proyecto NO encontrado!"); // Devuelve un resultado NotFound si el proyecto no se encuentra.
            }
            var result = await _unitOfWork.ProyectosRepository.Update(new Proyectos
            {
                CodProyecto = codProyecto,
                Nombre = proyecto.Nombre,
                Direccion = proyecto.Direccion,
                Estado = proyecto.Estado,
                Activo = false
            });
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el proyecto");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }
        }
    }
}
