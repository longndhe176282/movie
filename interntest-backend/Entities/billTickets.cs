using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class billTickets
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BillId { get; set; }
        public int TicketId { get; set; }

        [ForeignKey("BillId")]
        public virtual bills Bills { get; set; }

        [ForeignKey("TicketId")]
        public virtual tickets Tickets { get; set; }

        public billTickets(int quantity, int billId, int ticketId)
        {
            Quantity = quantity;
            BillId = billId;
            TicketId = ticketId;
        }
    }
}
