namespace InternTest_Backend.Models
{
    public class UpdateCinemaRequest
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string NameOfCinema { get; set; }
        public bool IsActive { get; set; }
    }
}
