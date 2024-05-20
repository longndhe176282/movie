using InternTest_Backend.Requests;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : Controller
    {
        private TicketService ticketService = new TicketService();

        [HttpPost("load-ticket")]
        public IActionResult LoadTicket(LoadTicketRequest request)
        {
            return Ok(ticketService.LoadTicket(request));
        }
    }
}
