namespace InternTest_Backend.Requests
{
    public class CreateBillRequest
    {
        public double TotalMoney { get; set; }
        public string TradingCode { get; set; }
        public DateTime CreateTime { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public int PromotionId { get; set; }
        public bool IsActive { get; set; }
        public int BillStatusId { get; set; }
        public int? FoodQuantity { get; set; }
        public int? FoodId { get; set; }
        public int TicketQuantity { get; set; }
        public int TicketId { get; set; }
    }
}
