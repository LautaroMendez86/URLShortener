using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Data.Service.Interfaces;
using URLShortener.Data;
using URLShortener.Entities;

namespace URLShortener.Controllers
{
    [Route("")]
    [ApiController]
    public class XYZRedirect : ControllerBase
    {
        private readonly IXYZRepository _xyzRepository;
        public XYZRedirect(IXYZRepository xyzRepository)
        {
            _xyzRepository = xyzRepository;
        }

        [HttpGet("{hash}")]

        public IActionResult RedirectToExternalPage(string hash)
        {
            XYZ xyz = _xyzRepository.GetOneByHash(hash);
            _xyzRepository.UpdateVisit(xyz);
            return Redirect(xyz.URL);
        }
    }
}
