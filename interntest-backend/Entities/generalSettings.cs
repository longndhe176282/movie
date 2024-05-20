using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class generalSettings
    {
        [Key]
        public int Id { get; set; }
        public DateTime BreakTime { get; set; }
        public int BussinesHours { get; set; }
        public DateTime CloseTime { get; set; }
        public double FixedTicketPrice { get; set; }
        public double PercentDay { get; set; }
        public double PercentWeekend { get; set;}
        public DateTime TimeBeginToChange { get; set; }

    }
}
