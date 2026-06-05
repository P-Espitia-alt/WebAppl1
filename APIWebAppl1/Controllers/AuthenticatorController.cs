using APIWebAppl1.DTO;
using APIWebAppl1.Helpers;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIWebAppl1.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatorController : ControllerBase
    {
        private readonly IAstronautaRepository _astronautaRepository;
        private readonly JwtHelper _jwtHelper;

        public AuthenticatorController(IAstronautaRepository astronautaRepository, JwtHelper jwtHelper)
        {
            _astronautaRepository = astronautaRepository;
            _jwtHelper = jwtHelper;

        }

        [HttpPost("login", Name = "Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var astronauta = await _astronautaRepository.LoginAsync(request.Usuario.Trim(), request.Contrasena);

                if (astronauta is null)
                {
                    return Unauthorized(new ApiResponse<string>
                    {
                        Data = string.Empty,
                        Message = "Usuario o contraseña incorrectos",
                        StatusCode = 401
                    });
                }

                astronauta.Token = _jwtHelper.GenerateToken(astronauta.Usuario, astronauta.AstronautaId);
                await _astronautaRepository.UpdateById(astronauta.AstronautaId, astronauta);

                return Ok(new ApiResponse<string>
                {
                    Data = astronauta.Token,
                    Message = "Login exitoso",
                    StatusCode = 200
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Data = ex.Message,
                    Message = "No se pudo realizar el inicio de sesión",
                    StatusCode = 500
                });
            }
        }
    }
}
