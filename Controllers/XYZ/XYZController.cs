using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using URLShortener.Data.Service.Interfaces;
using URLShortener.Models.DTO.XYZ;

namespace URLShortener.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class XYZController : ControllerBase
    {

        private readonly IXYZRepository _xyzRepository;

        public XYZController(IXYZRepository xyzRepository)
        {
            _xyzRepository = xyzRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out int userId);
            return Ok(_xyzRepository.Index(userId));
        }

        [HttpPost]
        public IActionResult Create(XYZForCreationDto dto)
        {
            try
            {
                int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out int userId);
                _xyzRepository.Create(dto, userId);
                return Ok("Registro creado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult Update(XYZForUpdateDTO dto)
        {
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out int userId);
            _xyzRepository.Update(dto, userId);
            return Ok("Se ha actualizado correctamente");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _xyzRepository.Delete(id);
            return Ok("Se ha eliminado correctamente");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            return Ok(_xyzRepository.GetOne(id));   
        }
    }
}
