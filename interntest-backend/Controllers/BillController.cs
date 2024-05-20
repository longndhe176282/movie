using InternTest_Backend.Interfaces;
using InternTest_Backend.Requests;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/bill")]
    [ApiController]
    public class BillController : Controller
    {
        private readonly BillService _billService = new BillService();

        [HttpPost("create-bill")]
        public IActionResult createBill(CreateBillRequest request)
        {
            return Ok(_billService.CreateBill(request));
        }

        [HttpPost("pay-bill")]
        public IActionResult PayBill(double price, string movieName)
        {
            return Ok(_billService.PayBill(HttpContext, price, movieName));
        }

        [HttpGet("pay-success")]
        [Authorize]
        public IActionResult Páyuccess()
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            return Ok(_billService.PayLastBillSuccess(accessToken));
        }
    }
}
