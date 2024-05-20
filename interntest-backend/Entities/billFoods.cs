using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class billFoods
    {
        [Key]
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int BillId { get; set; }
        public int? FoodId { get; set; }

        [ForeignKey("BillId")]
        public virtual bills Bills { get; set; }
        [ForeignKey("FoodId")]
        public virtual foods Foods { get; set; }

        public billFoods(int? quantity, int billId, int? foodId)
        {
            Quantity = quantity;
            BillId = billId;
            FoodId = foodId;
        }
    }
}
