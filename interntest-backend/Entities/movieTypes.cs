using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class movieTypes
    {
        [Key]
        public int Id { get; set; }
        public string MovieTypeName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<movies> Movies { get; set; }
    }
}
