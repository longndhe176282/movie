using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class rates
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public virtual ICollection<movies> Movies { get; set; }
    }
}
