using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using URLShortener.Data.Services.Interfaces;
using URLShortener.Models.DTO.User;

/// <summary>
/// StackOverflow example
/// </summary>
/// <response code="200">All good here</response>
/// <response code="401">Unauthorized</response>

namespace URLShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_userRepository.Index());
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(UserToCreateDto userDto)
        {
            _userRepository.Create(userDto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UserToUpdateDto userDto)
        {
            _userRepository.Update(userDto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return Ok();
        }

    }
}
