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

            try
            {
                var Astronauta = await _astronautaRepository.LoginAsync(request.Usuario, request.Contrasena);
                if (Astronauta != null)
                {
                     var token = _jwtHelper.GenerateToken(Astronauta.Usuario, Astronauta.AstronautaId);
                    await _astronautaRepository.UpDateTokenAsync(Astronauta.AstronautaId, token);

                    ApiResponse<string> response = new()
                    {
                        Data = token,
                        Message = "Login exitoso",
                        StatusCode = 200
                    };
                    return Ok(response);
                }
                else
                {
                    ApiResponse<string> response = new()
                    {
                        Data = " :(( ",
                        Message = "Usuario o contraseña incorrectos",
                        StatusCode = 401
                    };
                    return Unauthorized(response);
                }
            }
            catch (Exception ex)
            {
                ApiResponse<string> response = new()
                {
                    Data = ex.Message,
                    Message = "No se pudo realizar el inicio de sesión",
                    StatusCode = 500
                };
                return StatusCode(500, response);
            }

            
        }
    }
}
