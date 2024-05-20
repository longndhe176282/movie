using InternTest_Backend.Models;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/movie")]
    [ApiController]

    public class MovieController : Controller
    {
        private readonly MovieService movieService;

        public MovieController()
        {
            movieService = new MovieService();
        }

        [HttpPost("load-movie")]
        public IActionResult LoadMovie(LoadMovieRequest request)
        {
            return Ok(movieService.LoadMovie(request));
        }


        [HttpPost("add-new-movie")]
        public IActionResult AddNewMovie(NewMovieRequest newMovie)
        {
            return Ok(movieService.AddNewMovie(newMovie));
        }

        [HttpPost("update-movie")]
        public IActionResult UpdateMovie(UpdateMovieRequest updateMovie)
        {
            return Ok(movieService.UpdateMovie(updateMovie));
        }

        [HttpPost("delete-movie")]
        public IActionResult DeleteMovie(int id)
        {
            return Ok(movieService.DeleteMovie(id));
        }
    }
}
