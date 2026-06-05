using APIWebAppl1.DTO;
using ClassLibraryInfrastructure1.Data.Entities;
using ClassLibraryInfrastructure1.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace APIWebAppl1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MisionesController : ControllerBase
    {
        private readonly IMisionRepository _misionRepository;

        public MisionesController(IMisionRepository misionRepository)
        {
            _misionRepository = misionRepository;
        }


        [HttpGet("search", Name = "GetAllMisiones")]
        public async Task<IActionResult> GetAllMisionesAsync()
        {
            try
            {
                List<Mision> Misiones = new();
                Misiones = await _misionRepository.GetAllAsync();

                ApiResponse<List<Mision>> response = new()
                {
                    Data = Misiones,
                    Message = "Misiones obtenidas exitosamente",
                    StatusCode = 200

                };
                return Ok(response);

            }
            catch (Exception )
            {
                ApiResponse<string> response = new()
                {
                    Data = " :(( ",
                    Message = "No se pudo obtener lista de Misiones",
                    StatusCode = 500
                };
                return StatusCode(500, response);
            }
        }




        [HttpGet("{id}", Name = "GetMisionById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            
            try
            {
                var mision = await _misionRepository.GetByIdAsync(id);
                if (mision != null)
                {
                    ApiResponse<Mision> response = new()
                    {
                        Data = mision,
                        Message = "Mision encontrada exitosamente",
                        StatusCode = 200

                    };
                    return Ok(response);
                }
                else
                {
                    ApiResponse<Mision> response = new()
                    {
                        Data = null,
                        Message = "Mision no encontrada",
                        StatusCode = 404

                    };
                    return NotFound(response);
                }
            }
            catch (Exception )
            {
                ApiResponse<string> response = new()
                {
                    Data = " :(( ",
                    Message = "No se pudo encontrar la mision",
                    StatusCode = 500
                };
                return StatusCode(500, response);
            }
        }



        ///crear
        [HttpPost("create", Name = "CreateMision")]
        public async Task<IActionResult> CreateAsync([FromBody] Mision mision) 
        {
            try
            {
                await _misionRepository.CreateAsync(mision);
                ApiResponse<Mision> response = new()
                {
                    Data = mision,
                    Message = "Mision creada exitosamente",
                    StatusCode = 201

                };
                return StatusCode(201, response);

            }
            catch (Exception ) 
            {
                ApiResponse<string> response = new()
                {
                    Data = " :(( ",
                    Message = "No se pudo crear la mision",
                    StatusCode = 500
                };
                return StatusCode(500, response);
            }
        }


        //update
        [HttpPut("update/{id}", Name = "UpdateMision")]
        public async Task<IActionResult> UpDateAsync(int id, [FromBody] Mision mision)
        {
            try
            {
                await _misionRepository.UpDateAsync(mision);
                ApiResponse<Mision> response = new()
                {
                    Data = mision,
                    Message = "Mision actualizada exitosamente",
                    StatusCode = 200

                };  
                return Ok(response);

            }
            catch (Exception)
            {
                ApiResponse<string> response = new()
                {
                    Data = " :(( ",
                    Message = "No se pudo actualizar la mision",
                    StatusCode = 500
                };
                return StatusCode(500, response);
            } 
        }


        ///Delete
        [HttpDelete("delete/{id}", Name = "DeleteMision")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _misionRepository.DeleteAsync(id);
                ApiResponse<string> response = new()
                {
                    Data = "Mision eliminada",
                    Message = "Mision eliminada exitosamente",
                    StatusCode = 200
                };
                return Ok(response);
            }
            catch (Exception)
            {
                ApiResponse<string> response = new()
                {
                    Data = " :(( ",
                    Message = "No se pudo eliminar la mision",
                    StatusCode = 500
                };
                return StatusCode(500, response);
            }
        }
    }
}
