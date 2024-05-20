using InternTest_Backend.Interfaces;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/seat-type")]
    [ApiController]
    public class SeatTypeController : Controller
    {
        private readonly SeatTypeService seatTypeService = new SeatTypeService();

        [HttpGet("load-seat-type")]
        public IActionResult LoadSeatType()
        {
            return Ok(seatTypeService.LoadSeatType());
        }
    }
}
