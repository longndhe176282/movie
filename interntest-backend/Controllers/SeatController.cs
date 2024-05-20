using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/seat")]
    [ApiController]
    public class SeatController : Controller
    {
        private readonly SeatService seatService = new SeatService();

        [HttpGet("load-seat")]
        public IActionResult LoadSeat()
        {
            return Ok(seatService.LoadSeat());
        }

        [HttpPost("update-seat")]
        public IActionResult UpdateSeat(UpdateSeatRequest seat)
        {
            return Ok(seatService.UpdateSeat(seat));
        }

        [HttpPost("add-new-seat")]
        public IActionResult AddNewSeat(NewSeatRequest seat)
        {
            return Ok(seatService.AddNewSeat(seat));
        }

        [HttpPost("delete-seat")]
        public IActionResult DeleteSeat(int id)
        {
            return Ok(seatService.DeleteSeat(id));
        }
    }
}
