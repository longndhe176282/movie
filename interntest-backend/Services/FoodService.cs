using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace InternTest_Backend.Services
{
    public class FoodService : IFoodService
    {
        private AppDbContext _context = new AppDbContext();

        private bool isExistedId(int id)
        {
            foreach (foods f in _context.foods.ToList())
            {
                if (f.Id == id && f.IsActive == true)
                {
                    return true;
                }
            }
            return false;
        }

        public string AddNewFood(NewFoodRequest newFood)
        {
            foods temp = new foods(newFood.Price, newFood.Description, newFood.image, newFood.NameOfFood, newFood.IsActive);
            _context.foods.Add(temp);
            _context.SaveChanges();
            return "Đã thêm thành công";
        }

        public string DeleteFood(int id)
        {
            if (!isExistedId(id))
            {
                return "Thực phẩm đã ngừng kinh doanh";
            }
            _context.foods.FirstOrDefault(f => f.Id == id).IsActive = false;
            _context.SaveChanges();
            return "Đã xóa thành công";
        }

        public List<foods> LoadFood()
        {
            return _context.foods.Where(x => x.IsActive == true).Include(x => x.BillFoods).ThenInclude(x => x.Bills).ToList();
        }

        public string UpdateFood(UpdateFoodRequest updatingFood)
        {
            if (!isExistedId(updatingFood.Id))
            {
                return "Id không tồn tại";
            }
            foods oldFood = _context.foods.FirstOrDefault(f => f.Id == updatingFood.Id);
            oldFood.image = updatingFood.image;
            oldFood.IsActive = updatingFood.IsActive;
            oldFood.Description = updatingFood.Description;
            oldFood.NameOfFood = updatingFood.NameOfFood;
            oldFood.Price = updatingFood.Price;
            _context.SaveChanges();
            return "Đã cập nhật thành công";
        }
    }
}
