using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/banner")]
    [ApiController]
    public class BannerController : Controller
    {
        private readonly BannerService bannerService = new BannerService();

        [HttpGet("load-banner")]

        public IActionResult LoadBanner()
        {
            return Ok(bannerService.LoadBanner());
        }
    }
}
