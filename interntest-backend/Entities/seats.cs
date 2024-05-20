using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class seats
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int SeatStatusId { get; set; }
        public string Line { get; set; }
        public int RoomId { get; set; }
        public bool IsActive { get; set; }
        public int SeatTypeId { get; set; }

        [ForeignKey("SeatTypeId")]
        public virtual seatTypes SeatTypes { get; set; }

        [ForeignKey("RoomId")]
        public virtual rooms Rooms { get; set; }

        [ForeignKey("SeatStatusId")]
        public virtual seatsStatus SeatsStatus { get; set; }

        public virtual ICollection<tickets> Tickets { get; set; }

        public seats(int number, int seatStatusId, string line, int roomId, bool isActive, int seatTypeId)
        {
            Number = number;
            SeatStatusId = seatStatusId;
            Line = line;
            RoomId = roomId;
            IsActive = isActive;
            SeatTypeId = seatTypeId;
        }
    }
}
