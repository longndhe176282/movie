using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using InternTest_Backend.Requests;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService userService = new UserService();

        [HttpGet("load-user")]
        public IActionResult LoadUser()
        {
            return Ok(userService.LoadUser());
        }

        [HttpPost("delete-user")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(userService.DeleteUser(id));
        }

        [HttpPost("update-profile")]
        [Authorize]
        public IActionResult UpdateUserProfile([FromBody] UpdateProfileRequest request)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            return Ok(userService.UpdateUserProfile(accessToken, request));
        }

        [HttpPost("change-password")]
        [Authorize]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            return Ok(userService.ChangePassword(accessToken, request));
        }

        [HttpPost("update-user")]
        public IActionResult UpdateUser(UpdateUserRequest user)
        {
            return Ok(userService.UpdateUser(user));
        }

        [HttpPost("get-access-token")]
        public IActionResult getAccessToken(int userId)
        {
            return Ok(userService.getAccessToken(userId));
        }

        [HttpPost("add-new-user")]
        public IActionResult AddNewUser(NewUserRequest user)
        {
            return Ok(userService.AddNewUser(user));
        }

        [HttpPost("forget-password")]
        public IActionResult ForgetPassword(string email)
        {
            return Ok(userService.ForgetPassword(email));
        }

        [HttpPost("confirm-register-email")]
        public IActionResult ConfirmRegisterEmail(string email, string confirmCode)
        {
            return Ok(userService.ConfirmRegisterEmail(email, confirmCode));
        }

        [HttpPost("confirm-reset-email")]
        public IActionResult ConfirmResetEmail(string email, string resetCode)
        {
            return Ok(userService.ConfirmResetEmail(email, resetCode));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginModel)
        {
            return Ok(userService.Login(loginModel));
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerModel)
        {
            return Ok(userService.Register(registerModel));
        }
    }
}
