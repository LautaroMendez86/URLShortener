using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Data.Service.Interfaces;
using URLShortener.Models.DTO.Category;

namespace URLShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_categoryRepository.Index());
        }


        [HttpPost]
        public IActionResult Create(CategoryForCreation categoryForCreation)
        {

            _categoryRepository.Create(categoryForCreation);
            return Ok("Categoria creada correctamente");

        }

        [HttpPut]
        public IActionResult Update(CategoryForUpdateDTO dto)
        {
            _categoryRepository.Update(dto);
            return Ok("Categoria actualizada correctamente");
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        [HttpGet]
        [Route("{ID}")]
        public IActionResult GetOneByID(int id)
        {
            return Ok(_categoryRepository.GetOneByID(id));
        }
    }
}
