using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using InternTest_Backend.Requests;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly RoomService roomService = new RoomService();

        [HttpPost("load-room")]
        public IActionResult LoadRoom(LoadRoomRequest request)
        {
            return Ok(roomService.LoadRoom(request));
        }

        [HttpPost("update-room")]
        public IActionResult UpdateRoom(UpdateRoomRequest room)
        {
            return Ok(roomService.UpdateRoom(room));
        }

        [HttpPost("add-new-room")]
        public IActionResult AddNewRoom(NewRoomRequest room)
        {
            return Ok(roomService.AddNewRoom(room));
        }

        [HttpPost("delete-room")]
        public IActionResult DeleteRoom(int id)
        {
            return Ok(roomService.DeleteRoom(id));
        }
    }
}
