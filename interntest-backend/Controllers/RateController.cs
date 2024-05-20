using InternTest_Backend.Interfaces;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/rate")]
    [ApiController]
    public class RateController : Controller
    {
        private readonly RateService rateService = new RateService();

        [HttpGet("load-rate")]
        public IActionResult LoadRate()
        {
            return Ok(rateService.LoadRate());
        }
    }
}
