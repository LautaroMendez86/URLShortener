using Microsoft.AspNetCore.Mvc;
using URLShortener.Data;
using URLShortener.Data.Service.Interfaces;
using URLShortener.Entities;
using URLShortener.Models.DTO.XYZ;

namespace URLShortener.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(_xyzRepository.Index());
        }

        [HttpPost]
        public IActionResult Create(XYZForCreationDto dto)
        {

            try
            {
                _xyzRepository.Create(dto);
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
            _xyzRepository.Update(dto);
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
