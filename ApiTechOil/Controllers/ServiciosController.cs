using ApiTechOil.DataAccess.Repositories;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using ApiTechOil.DTOs;
using ApiTechOil.Entities;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiTechOil.Controllers
{
    [Route("api/Servicios")]
    [ApiController]
    [Authorize]
    public class ServiciosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiciosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Servicios>>> GetAll()
        {
            var servicios = await _unitOfWork.ServiciosRepository.GetAll();

            return servicios;
        }

        [HttpGet]
        [Route("estado/{estado}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Servicios>>> GetByEstado(bool estado)
        {
            var servicios = await _unitOfWork.ServiciosRepository.GetByEstado(estado);
            if (servicios != null)
            {
                return servicios;
            }
            return NotFound();
        }

        [HttpGet("{codServicio}")]
        [AllowAnonymous]
        public async Task<ActionResult<Servicios>> GetServicioById(int codServicio)
        {
            var servicio = await _unitOfWork.ServiciosRepository.GetById(codServicio);
            if (servicio == null)
            {
                return NotFound(); // Devuelve un resultado NotFound si el proyecto no se encuentra.
            }
            return servicio;
        }

        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ServiciosDto dto)
        {
            await _unitOfWork.ServiciosRepository.Insert(new Servicios(dto));
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [Authorize(Policy = "Administrador")]
        [HttpPut("{codServicio}")]
        public async Task<IActionResult> Update([FromRoute] int codServicio, ServiciosDto dto)
        {
            var result = await _unitOfWork.ServiciosRepository.Update(new Servicios(dto, codServicio));
            if (result) await _unitOfWork.Complete();
            return Ok(result);
        }

        [Authorize(Policy = "Administrador")]
        [HttpDelete("{codServicio}")]
        public async Task<IActionResult> Delete([FromRoute] int codServicio)
        {
            Servicios servicios = await _unitOfWork.ServiciosRepository.GetById(codServicio);
            if (servicios == null)
            {
                return NotFound(); // Devuelve un resultado NotFound si el servicio no se encuentra.
            }
            var result = await _unitOfWork.ServiciosRepository.Update(new Servicios
            {
                CodServicio = codServicio,
                Descr = servicios.Descr,
                Estado = false,
            });
            if (result) await _unitOfWork.Complete();
            return Ok(result);
        }
    }
}
