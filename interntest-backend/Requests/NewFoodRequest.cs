namespace InternTest_Backend.Models
{
    public class NewFoodRequest
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public string image { get; set; }
        public string NameOfFood { get; set; }
        public bool IsActive { get; set; }
    }
}
