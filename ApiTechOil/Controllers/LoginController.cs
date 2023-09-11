using ApiTechOil.DTOs;
using ApiTechOil.Helpers;
using ApiTechOil.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechOil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LoginController : Controller
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var userCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);
            if (userCredentials is null) return Unauthorized("Las credenciales son incorrectas");

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var usuario = new UsuarioLoginDto()
            {
                Nombre = userCredentials.Nombre,
                Email = userCredentials.Email,
                Token = token
            };
            return Ok(usuario);
        }
    }
}
