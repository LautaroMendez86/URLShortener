using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;
using URLShortener.Data;
using URLShortener.Entities;
using URLShortener.Models;

namespace URLShortener.Controllers
{

    [Route("")]
    [ApiController]
    public class XYZController : ControllerBase
    {

        private readonly UrlShortenerContext _context;
        public XYZController(UrlShortenerContext context)
        {
            _context = context;
        }

        [HttpGet("{hash}")]

        public IActionResult RedirectToExternalPage(string hash)
        {
            return Redirect(_context.XYZs.Single(x => x.Hash == hash).URL);
        }

        [HttpGet]
        [Route("api/xyz/get-all")]
        public IActionResult GetAll()
        {
            return Ok(_context.XYZs.ToList());
        }

        [HttpGet]
        [Route("api/xyz/get-one-hash")]
        public IActionResult GetOneHash(string url)
        {
            try
            {
                return Ok(_context.XYZs.Single(x => x.URL == url).Hash);
            }
            catch (Exception ex)
            {
                return BadRequest("No creaste un Hash para la URL ingresada. " + ex.Message);
            }

        }

        [HttpPost]
        [Route("api/xyz/create-hash")]
        public async Task<IActionResult> CreateHash(XYZForCreationDto dto)
        {

            bool isExist = _context.XYZs.Any(x => x.URL == dto.URL);

            if (isExist) return Ok("Ya existe un hash para esa URL");

            var xyz = new XYZ
            {
               URL = dto.URL,
               Hash = HashGenerate(dto.URL)
            };

            _context.XYZs.Add(xyz);

            await _context.SaveChangesAsync();

            return Ok("Registro creado exitosamente");
          
        }

        private static string HashGenerate(string url)
        {
            byte[] hashValue = SHA256.HashData(Encoding.UTF8.GetBytes(url));
            return Convert.ToBase64String(hashValue)[..6];
        }
    }
}
