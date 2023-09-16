using ApiTechOil.Services;
using Microsoft.AspNetCore.Mvc;
using ApiTechOil.Entities;
using ApiTechOil.DTOs;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<IEnumerable<Proyectos>>> GetAll()
        {
            var proyectos = await _unitOfWork.ProyectosRepository.GetAll();

            return proyectos;
        }
        [HttpGet("{codProyecto}")]
        [AllowAnonymous]
        public async Task<ActionResult<Proyectos>> GetProyectoById(int codProyecto)
        {
            var proyecto = await _unitOfWork.ProyectosRepository.GetById(codProyecto);
            if (proyecto == null)
            {
                return NotFound(); // Devuelve un resultado NotFound si el proyecto no se encuentra.
            }
            return proyecto;
        }

        [HttpGet]
        [Route("/estado/{estado}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Proyectos>>> GetByEstado(int estado)
        {
            var proyectos = await _unitOfWork.ProyectosRepository.GetByEstado(estado);
            if (proyectos != null)
            {
                return proyectos;
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ProyectosDto dto)
        {
            await _unitOfWork.ProyectosRepository.Insert(new Proyectos(dto));
            await _unitOfWork.Complete();
            return Ok(true);
        }
        [HttpPut("{codProyecto}")]
        public async Task<IActionResult> Update([FromRoute] int codProyecto, ProyectosDto dto)
        {
            var result = await _unitOfWork.ProyectosRepository.Update(new Proyectos(dto, codProyecto));
            if (result) await _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpDelete("{codProyecto}")]

        public async Task<IActionResult> Delete([FromRoute] int codProyecto)
        {
            Proyectos proyectos = await _unitOfWork.ProyectosRepository.GetById(codProyecto);
            if (proyectos == null)
            {
                return NotFound(); // Devuelve un resultado NotFound si el usuario no se encuentra.
            }
            var result = await _unitOfWork.ProyectosRepository.Update(new Proyectos
            {
                CodProyecto = codProyecto,
                Nombre = proyectos.Nombre,
                Direccion = proyectos.Direccion,
                Estado = proyectos.Estado,
                Activo = false
            });
            if (result) await _unitOfWork.Complete();
            return Ok(result);
        }
    }
}
