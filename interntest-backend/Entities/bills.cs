using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class bills
    {
        [Key]
        public int Id { get; set; }
        public double TotalMoney { get; set; }
        public string TradingCode { get; set; }
        public DateTime CreateTime { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public int PromotionId { get; set; }
        public bool IsActive { get; set; }
        public int BillStatusId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual users Users { get; set; }

        [ForeignKey("PromotionId")]
        public virtual promotions Promotions { get; set; }

        [ForeignKey("BillStatusId")]
        public virtual billStatuses BillStatuses { get; set; }

        public virtual billFoods BillFoods { get; set; }

        public virtual ICollection<billTickets> BillTickets { get; set; }

        public bills(double totalMoney, string tradingCode, DateTime createTime, int customerId, string name, DateTime createAt, int promotionId, bool isActive, int billStatusId)
        {
            TotalMoney = totalMoney;
            TradingCode = tradingCode;
            CreateTime = createTime;
            CustomerId = customerId;
            Name = name;
            CreateAt = createAt;
            PromotionId = promotionId;
            IsActive = isActive;
            BillStatusId = billStatusId;
        }
    }
}
