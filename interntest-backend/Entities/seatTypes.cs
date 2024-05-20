using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class seatTypes
    {
        [Key]
        public int Id { get; set; }
        public string NameType { get; set; }

        public virtual ICollection<seats> Seats { get; set; }
    }
}
