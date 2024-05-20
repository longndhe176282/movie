using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class seatsStatus
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameStatus { get; set; }

        public virtual ICollection<seats> Seats { get; set; }
    }
}
