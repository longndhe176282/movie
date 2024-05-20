using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class roles
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<users> Users { get; set; }
    }
}
