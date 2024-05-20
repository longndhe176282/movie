namespace InternTest_Backend.Models
{
    public class NewSeatRequest
    {
        public int Number { get; set; }
        public int SeatStatusId { get; set; }
        public string Line { get; set; }
        public int RoomId { get; set; }
        public bool IsActive { get; set; }
        public int SeatTypeId { get; set; }
    }
}
