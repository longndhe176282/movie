using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class rooms
    {
        [Key]
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public int CinemaId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<schedules> Schedules { get; set; }

        public virtual ICollection<seats> Seats { get; set; }

        [ForeignKey("CinemaId")]
        public virtual cinemas Cinemas { get; set; }

        public rooms( int capacity, int type, string description, int cinemaId, string code, string name, bool isActive)
        {
            Capacity = capacity;
            Type = type;
            Description = description;
            CinemaId = cinemaId;
            Code = code;
            Name = name;
            IsActive = isActive;
        }
    }
}
