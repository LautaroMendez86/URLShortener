using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
using URLShortener.Entities;
using URLShortener.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace URLShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly UrlShortenerContext _context;
        public CategoryController(UrlShortenerContext urlShortener)
        {
            _context = urlShortener;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Index(int id)
        {
            return Ok(_context.Categories.Where(x => x.ID == id).ToList());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]

        [Route("create")]
        public async Task<IActionResult> Post(CategoryForCreation categoryForCreation)
        {

            Category category = new Category
            {
                Name = categoryForCreation.Name
            };

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return Ok("Categoria creada correctamente");

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
