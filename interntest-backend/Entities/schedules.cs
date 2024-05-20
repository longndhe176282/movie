using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace InternTest_Backend.Entities
{
    public class schedules
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Code { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("MovieId")]
        public virtual movies Movies { get; set; }

        [ForeignKey("RoomId")]
        public virtual rooms Rooms { get; set; }

        public virtual ICollection<tickets> Tickets { get; set; }

        public schedules(double price, DateTime startAt, DateTime endAt, string code, int movieId, string name, int roomId, bool isActive)
        {
            Price = price;
            StartAt = startAt;
            EndAt = endAt;
            Code = code;
            MovieId = movieId;
            Name = name;
            RoomId = roomId;
            IsActive = isActive;
        }
    }
}
