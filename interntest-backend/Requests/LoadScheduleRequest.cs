namespace InternTest_Backend.Requests
{
    public class LoadScheduleRequest
    {
        public int? LowerPrice { get; set; }
        public int? UpToPrice { get; set; }
        public DateTime? LowerDate { get; set; }
        public DateTime? UpToDate { get; set; }
        public int? MovieId { get; set; }
        public int? CinemaId { get; set; }
        public int? RoomId { get; set; }
    }
}
