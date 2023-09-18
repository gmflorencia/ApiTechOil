using ApiTechOil.DTOs;
using ApiTechOil.Entities;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfilUsuario>>> GetAll()
        {
            var PerfilUsuario = await _unitOfWork.PerfilUsuarioRepository.GetAll();

            return PerfilUsuario;
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<PerfilUsuario>> GetById(int id)
        {
            var perfilUsuario = await _unitOfWork.PerfilUsuarioRepository.GetById(id);
            if (perfilUsuario == null)
            {
                return NotFound();
            }
            return perfilUsuario;
        }

        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("PerfilUsuario")]
        public async Task<IActionResult> Insert(PerfilUsuarioDto dto)
        {

            var perfilUsuario = new PerfilUsuario(dto);
            await _unitOfWork.PerfilUsuarioRepository.Insert(perfilUsuario);
            await _unitOfWork.Complete();
            return Ok(true);

        }

        [Authorize(Policy = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, PerfilUsuarioDto dto)
        {
            var result = await _unitOfWork.PerfilUsuarioRepository.Update(new PerfilUsuario(dto, id));

            await _unitOfWork.Complete();
            return Ok(true);
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
            if (result) await _unitOfWork.Complete();
            return Ok(result);
        }
    }
}
