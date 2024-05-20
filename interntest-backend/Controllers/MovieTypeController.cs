using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/movie-type")]
    [ApiController]
    public class MovieTypeController : Controller
    {
        private readonly MovieTypeService movieTypeService;

        public MovieTypeController()
        {
            movieTypeService = new MovieTypeService();
        }

        [HttpGet("load-movie-type")]
        public IActionResult LoadMovie()
        {
            return Ok(movieTypeService.LoadMovieType());
        }
    }
}
