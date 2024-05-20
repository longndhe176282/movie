using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using InternTest_Backend.Requests;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private readonly ScheduleService scheduleService = new ScheduleService();

        [HttpPost("load-schedule")]
        public IActionResult LoadSchedule(LoadScheduleRequest request)
        {
            return Ok(scheduleService.LoadSchedule(request));
        }

        [HttpPost("delete-schedule")]
        public IActionResult DeleteSchedule(int id)
        {
            return Ok(scheduleService.DeleteSchedule(id));
        }

        [HttpPost("add-new-schedule")]
        public IActionResult AddNewSchedule(NewScheduleRequest newSchedule)
        {
            return Ok(scheduleService.AddNewSchedule(newSchedule));
        }

        [HttpPost("update-schedule")]
        public IActionResult UpdateSchedule(UpdateScheduleRequest schedule)
        {
            return Ok(scheduleService.UpdateSchedule(schedule));
        }
    }
}
