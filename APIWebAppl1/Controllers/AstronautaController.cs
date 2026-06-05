using APIWebAppl1.DTO;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;



namespace APIWebAppl1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautaController : ControllerBase
    {

        private readonly IAstronautaRepository _astronautaRepository;


        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        public AstronautaController(IAstronautaRepository astronautaRepository)
        {
            _astronautaRepository = astronautaRepository;
        }

        

        [HttpGet("search", Name = "GetSearch")]
        public async Task<IActionResult> GetSearchAsync()
        {

            //lista de los astronautas
            //convertir lista de astronautas a Json
            //retornar lista

            try
            {
                List<Astronauta> Astronautas = new();
                Astronautas = await _astronautaRepository.GetAllAsync();
                List<AstronautaDTO> astronautasDTO = Astronautas.Select(a => new AstronautaDTO
                {
                    AstronautaId = a.AstronautaId,
                    Usuario = a.Usuario,
                    Nombre = a.Nombre,
                    Apellido = a.Apellido,
                    FechaNacimiento = a.FechaNacimiento,
                    PaisId = a.PaisId,
                    TotalMisiones = a.TotalMisiones
                }).ToList();

                ApiResponse<List<AstronautaDTO>> response = new()
                {
                    Data = astronautasDTO,
                    Message = "Lista de astronautas obtenida exitosamente",
                    StatusCode = 200
                };
                return Ok(response);
            }
            catch (Exception ex)
            {

                ApiResponse<string> response = new()
                {
                    Data = " :(( ",
                    Message = "No se pudo obtener lista de Astronautas",
                    StatusCode = 500
                };
                return StatusCode(500, response);
            }

        }

        [HttpGet("clonProgr2", Name = "GetWeatherForecastClone2")]
        public IEnumerable<WeatherForecast> GetWeatherForecastClone()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
