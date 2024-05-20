using InternTest_Backend.Interfaces;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/seats-status")]
    [ApiController]
    public class SeatsStatusController : Controller
    {
        private readonly SeatsStatusService _seatStatusService = new SeatsStatusService();

        [HttpGet("load-seats-status")]
        public IActionResult LoadSeatStatus()
        {
            return Ok(_seatStatusService.LoadSeatStatus());
        }
    }
}
