using ApiTechOil.DataAccess.Repositories;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using ApiTechOil.DTOs;
using ApiTechOil.Entities;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiTechOil.Infraestructure;

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
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _unitOfWork.ServiciosRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, servicios);
        }

        [HttpGet]
        [Route("estado/{estado}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByEstado(bool estado)
        {
            var servicios = await _unitOfWork.ServiciosRepository.GetByEstado(estado);
            if (!servicios.Any())
            {
                return ResponseFactory.CreateSuccessResponse(404, "NO existen servicios en esta condición " + estado);
            }
            return ResponseFactory.CreateSuccessResponse(200, servicios);
        }

        [HttpGet("{codServicio}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetServicioById(int codServicio)
        {
            var servicio = await _unitOfWork.ServiciosRepository.GetById(codServicio);
            if (servicio == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Servicio NO encontrado!"); // Devuelve un resultado NotFound si el proyecto no se encuentra.
            }
            return ResponseFactory.CreateSuccessResponse(200, servicio);
        }

        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ServiciosDto dto)
        {
            await _unitOfWork.ServiciosRepository.Insert(new Servicios(dto));
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Servicio registrado con exito!");
        }

        [Authorize(Policy = "Administrador")]
        [HttpPut("{codServicio}")]
        public async Task<IActionResult> Update([FromRoute] int codServicio, ServiciosDto dto)
        {
            var result = await _unitOfWork.ServiciosRepository.Update(new Servicios(dto, codServicio));
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el servicio");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }

        [Authorize(Policy = "Administrador")]
        [HttpDelete("{codServicio}")]
        public async Task<IActionResult> Delete([FromRoute] int codServicio)
        {
            Servicios servicio = await _unitOfWork.ServiciosRepository.GetById(codServicio);
            if (servicio == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Servicio NO encontrado!"); // Devuelve un resultado NotFound si el proyecto no se encuentra.
            }
            return ResponseFactory.CreateSuccessResponse(200, servicio);

            var result = await _unitOfWork.ServiciosRepository.Update(new Servicios
            {
                CodServicio = codServicio,
                Descr = servicio.Descr,
                Estado = false,
            });
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el servicio");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }
    }
}
