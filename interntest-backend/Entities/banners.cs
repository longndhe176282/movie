using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class banners
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }
}
