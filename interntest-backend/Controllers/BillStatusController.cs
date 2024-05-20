using InternTest_Backend.Requests;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/bill-status")]
    [ApiController]
    public class BillStatusController : Controller
    {
        private BillStatusService _billStatusService = new BillStatusService(); 

        [HttpPost("load-bill-status")]

        public IActionResult LoadBillStatuses(LoadBillStatusRequest request)
        {
            return Ok(_billStatusService.LoadBillStatuses(request));
        }
    }
}
