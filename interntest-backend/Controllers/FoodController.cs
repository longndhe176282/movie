using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using InternTest_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternTest_Backend.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodController : Controller
    {
        private readonly FoodService foodService = new FoodService();

        [HttpGet("load-food")]
        public IActionResult LoadFood()
        {
            return Ok(foodService.LoadFood());
        }

        [HttpPost("delete-food")]
        public IActionResult DeleteFood(int id)
        {
            return Ok(foodService.DeleteFood(id));
        }

        [HttpPost("add-new-food")]
        public IActionResult AddNewFood(NewFoodRequest newFood)
        {
            return Ok(foodService.AddNewFood(newFood));
        }

        [HttpPost("update-food")]
        public IActionResult UpdateFood(UpdateFoodRequest food)
        {
            return Ok(foodService.UpdateFood(food));
        }
    }
}
