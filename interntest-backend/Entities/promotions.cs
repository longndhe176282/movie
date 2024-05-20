using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class promotions
    {
        [Key]
        public int Id { get; set; }
        public int Percent {  get; set; }
        public int Quantity { get; set; }
        public int Type { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int RankCustomerId { get; set; }

        public virtual ICollection<bills> Bills { get; set; }

        [ForeignKey("RankCustomerId")]
        public virtual rankCustomers RankCustomers { get; set; }
    }
}
