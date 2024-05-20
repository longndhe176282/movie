using InternTest_Backend.Entities;
using InternTest_Backend.Models;

namespace InternTest_Backend.Interfaces
{
    public interface IFoodService
    {
        List<foods> LoadFood();
        string DeleteFood(int id);
        string AddNewFood(NewFoodRequest newFood);
        string UpdateFood(UpdateFoodRequest updatingFood);
    }
}
