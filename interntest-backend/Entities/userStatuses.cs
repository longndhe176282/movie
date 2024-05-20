using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class userStatuses
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<users> Users { get; set; }
    }
}
