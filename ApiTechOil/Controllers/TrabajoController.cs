using ApiTechOil.DTOs;
using ApiTechOil.Entities;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiTechOil.Infraestructure;
using ApiTechOil.Helpers;

namespace ApiTechOil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrabajoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrabajoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///  Devuelve todo los trabajos
        /// </summary>
        /// <returns>retorna un statusCode 200 todos los trabajos</returns>

        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trabajos = await _unitOfWork.TrabajoRepository.GetAll();
            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginadoTrabajos = PaginateHelper.Paginate(trabajos, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginadoTrabajos);
        }

        /// <summary>
        ///  Devuelve un trabajo
        /// </summary>
        /// <returns>retorna un statusCode 200 trabajo</returns>

        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet("{codTrabajo}")]
        public async Task<IActionResult> GetTrabajoById(int codTrabajo)
        {
            var trabajo = await _unitOfWork.TrabajoRepository.GetById(codTrabajo);
            if (trabajo == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Trabajo NO encontrado!"); // Devuelve un resultado NotFound si el proyecto no se encuentra.
            }
            return ResponseFactory.CreateSuccessResponse(200, trabajo);
        }

        /// <summary>
        ///  Registra un nuevo trabajo
        /// </summary>
        /// <returns>retorna un trabajo registrado con un statosCode 201</returns>

        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(TrabajoDto dto)
        {
            await _unitOfWork.TrabajoRepository.Insert(new Trabajo(dto));
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Trabajo registrado con exito!");
        }

        /// <summary>
        ///  Devuelve un trabajo 
        /// </summary>
        /// <returns>retorna un trabajo actualizado o un status code 201</returns>

        [Authorize(Policy = "Administrador")]
        [HttpPut("{codTrabajo}")]
        public async Task<IActionResult> Update([FromRoute] int codTrabajo, TrabajoDto dto)
        {
            var result = await _unitOfWork.TrabajoRepository.Update(new Trabajo(dto, codTrabajo));
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }

        /// <summary>
        ///  Elimina un trabajo
        /// </summary>
        /// <returns> retorna trabajo eliminado o un 500</returns>

        [Authorize(Policy = "Administrador")]
        [HttpDelete("{codTrabajo}")]
        public async Task<IActionResult> Delete([FromRoute] int codTrabajo)
        {
            Trabajo trabajos = await _unitOfWork.TrabajoRepository.GetById(codTrabajo);
            if (trabajos == null)
            {
                return ResponseFactory.CreateSuccessResponse(404, "Trabajo NO encontrado!"); // Devuelve un resultado NotFound si el proyecto no se encuentra.
            }
            var result = await _unitOfWork.TrabajoRepository.Update(new Trabajo
            {
                CodTrabajo = codTrabajo,
                CodProyecto = trabajos.CodProyecto,
                CodServicio = trabajos.CodServicio,
                Fecha = DateTime.Now,
                CantHoras=trabajos.CantHoras,
                ValorHora = trabajos.ValorHora,
                Costo=trabajos.Costo,
                Activo = false,
            });
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            }
        }
    }
}
