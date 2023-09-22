using ApiTechOil.DataAccess.Repositories;
using ApiTechOil.DataAccess.Repositories.Interfaces;
using ApiTechOil.DTOs;
using ApiTechOil.Entities;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiTechOil.Infraestructure;
using ApiTechOil.Helpers;

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

        /// <summary>
        ///  Devuelve todo los Servicios
        /// </summary>
        /// <returns>retorna un statusCode 200 todos los Servicios</returns>

        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _unitOfWork.ServiciosRepository.GetAll();
            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginadoServicios = PaginateHelper.Paginate(servicios, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginadoServicios);

        }

        /// <summary>
        ///  Devuelve todo los Servicios activos
        /// </summary>
        /// <returns>retorna un statusCode 200 todos los Servicios activos</returns>

        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("estado/{estado}")]
        public async Task<IActionResult> GetByEstado(bool estado)
        {
            var servicios = await _unitOfWork.ServiciosRepository.GetByEstado(estado);
            if (!servicios.Any())
            {
                return ResponseFactory.CreateSuccessResponse(404, "NO existen servicios en esta condición " + estado);
            }
            return ResponseFactory.CreateSuccessResponse(200, servicios);
        }

        /// <summary>
        ///  Devuelve un Servicio
        /// </summary>
        /// <returns>retorna un statusCode 200 un Servicio</returns>

        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet("{codServicio}")]
        public async Task<IActionResult> GetServicioById(int codServicio)
        {
            var servicio = await _unitOfWork.ServiciosRepository.GetById(codServicio);
            if (servicio == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Servicio NO encontrado!"); 
            }
            return ResponseFactory.CreateSuccessResponse(200, servicio);
        }

        /// <summary>
        ///  Registra un nuevo Servicio 
        /// </summary>
        /// <returns>retorna un Servicio registrado con un statusCode 200</returns>

        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ServiciosDto dto)
        {
            await _unitOfWork.ServiciosRepository.Insert(new Servicios(dto));
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Servicio registrado con exito!");
        }

        /// <summary>
        ///  Actualiza un Servicio
        /// </summary>
        /// <returns>retorna Servicio actualizado o un statusCode 201</returns>

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

        /// <summary>
        ///  Elimina un Servicio
        /// </summary>
        /// <returns> retorna Servicio eliminado o un 500</returns>

        [Authorize(Policy = "Administrador")]
        [HttpDelete("{codServicio}")]
        public async Task<IActionResult> Delete([FromRoute] int codServicio)
        {
            Servicios servicio = await _unitOfWork.ServiciosRepository.GetById(codServicio);
            if (servicio == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Servicio NO encontrado!"); 
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
