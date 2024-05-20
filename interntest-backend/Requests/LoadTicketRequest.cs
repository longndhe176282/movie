namespace InternTest_Backend.Requests
{
    public class LoadTicketRequest
    {
        public int? Id { get; set; }
        public int? MovieId { get; set; }
        public int? RoomId { get; set; }
        public int? ScheduleId { get; set; }
    }
}
