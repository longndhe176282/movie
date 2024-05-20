using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class rankCustomers
    {
        [Key] 
        public int Id { get; set; }
        public int Point { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<promotions> promotions { get; set; }
        public virtual ICollection<users> Users { get; set; }
    }
}
