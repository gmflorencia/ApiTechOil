using ApiTechOil.DTOs;
using ApiTechOil.Entities;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiTechOil.Controllers
{
    [Route("api/Trabajos")]
    [ApiController]
    [Authorize]
    public class TrabajosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrabajosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Trabajos>>> GetAll()
        {
            var trabajos = await _unitOfWork.TrabajosRepository.GetAll();

            return trabajos;
        }
        [HttpGet("{codTrabajo}")]
        [AllowAnonymous]
        public async Task<ActionResult<Trabajos>> GetTrabajoById(int codTrabajo)
        {
            var trabajo = await _unitOfWork.TrabajosRepository.GetById(codTrabajo);
            if (trabajo == null)
            {
                return NotFound(); // Devuelve un resultado NotFound si el proyecto no se encuentra.
            }
            return trabajo;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(TrabajosDto dto)
        {
            await _unitOfWork.TrabajosRepository.Insert(new Trabajos(dto));
            await _unitOfWork.Complete();
            return Ok(true);
        }
        [HttpPut("{codTrabajo}")]
        public async Task<IActionResult> Update([FromRoute] int codTrabajo, TrabajosDto dto)
        {
            var result = await _unitOfWork.TrabajosRepository.Update(new Trabajos(dto, codTrabajo));
            if (result) await _unitOfWork.Complete();
            return Ok(result);
        }
        [HttpDelete("{codTrabajo}")]

        public async Task<IActionResult> Delete([FromRoute] int codTrabajo)
        {
            Trabajos trabajos = await _unitOfWork.TrabajosRepository.GetById(codTrabajo);
            if (trabajos == null)
            {
                return NotFound(); // Devuelve un resultado NotFound si el trabajo no se encuentra.
            }
            var result = await _unitOfWork.TrabajosRepository.Update(new Trabajos
            {
                CodTrabajo = codTrabajo,
                Fecha = trabajos.Fecha,
                CantHoras=trabajos.CantHoras,
                ValorHora = trabajos.ValorHora,
                Costo=trabajos.Costo,
                Activo = false,
            });
            if (result) await _unitOfWork.Complete();
            return Ok(result);
        }
    }
    
}
