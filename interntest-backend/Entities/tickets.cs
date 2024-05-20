using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class tickets
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public int ScheduleId { get; set; }
        public int SeatId { get; set; }
        public bool IsActive { get; set; }
        public double PriceTicket { get; set; }

        public virtual ICollection<billTickets> BillTickets { get; set; }

        [ForeignKey("ScheduleId")]
        public virtual schedules Schedules { get; set; }

        [ForeignKey("SeatId")]
        public virtual seats Seats { get; set; }
    }
}
