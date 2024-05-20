namespace InternTest_Backend.Models
{
    public class LoadMovieRequest
    {
        public int? Id { get; set; }
        public int? CinemaId { get; set; }
        public int? RoomId { get; set; }
        public bool? filterWithEmptySeat { get; set; }
        public int? MovieTypeId { get; set; }
    }
}
