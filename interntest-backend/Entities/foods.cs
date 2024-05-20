using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class foods
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string image { get; set; }
        public string NameOfFood { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<billFoods> BillFoods { get; set; }

        public foods(double price, string description, string image, string nameOfFood, bool isActive)
        {
            Price = price;
            Description = description;
            this.image = image;
            NameOfFood = nameOfFood;
            IsActive = isActive;
        }
    }
}
