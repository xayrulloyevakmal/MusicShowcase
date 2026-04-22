using Microsoft.AspNetCore.Mvc;
using MusicShowcase.Services;

namespace MusicShowcase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly MusicGeneratorService _service;

        public SongsController(MusicGeneratorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetSongs(string locale = "en", int seed = 1, int page = 1, double likes = 0)
        {
            var data = _service.GenerateSongs(locale, seed, page, likes);
            return Ok(data);
        }

        [HttpGet("{id}/audio")]
        public IActionResult GetAudio(int id)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "sample.mp3");

            if (!System.IO.File.Exists(path))
                return NotFound("Audio file missing from wwwroot");

            return PhysicalFile(path, "audio/mpeg");
        }
    }
}