using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using InternTest_Backend.Requests;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/cinema")]
    [ApiController]
    public class CinemaController : Controller
    {
        private readonly CinemaService cinemaService;

        public CinemaController()
        {
            cinemaService = new CinemaService();
        }

        [HttpPost("load-cinema")]
        public IActionResult LoadCinema(LoadCinemaRequest request)
        {
            return Ok(cinemaService.LoadCinema(request));
        }

        [HttpPost("update-cinema")]
        public IActionResult UpdateCinema(UpdateCinemaRequest cinema)
        {
            return Ok(cinemaService.UpdateCinema(cinema));
        }

        [HttpPost("add-new-cinema")]
        public IActionResult AddNewCinema(NewCinemaRequest cinema)
        {
            return Ok(cinemaService.AddNewCinema(cinema));
        }

        [HttpPost("delete-cinema")]
        public IActionResult DeleteCinema(int id)
        {
            return Ok(cinemaService.DeleteCinema(id));
        }
    }
}
