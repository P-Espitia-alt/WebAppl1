using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;



namespace APIWebAppl1.Controllers
{

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
        public async Task<List<Astronauta>> GetSearchAsync()
        {

            //lista de los astronautas
            //convertir lista de astronautas a Json
            //retornar lista

            List<Astronauta> Astronautas = new();
            Astronautas = await _astronautaRepository.GetAllAsync();
            return Astronautas;
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
