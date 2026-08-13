namespace NSW.Core.DTOs
{
    public class PurchaseOrderItemDto
    {
        public int Id { get; set; }
        public int? PurchaseId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitCost { get; set; }
    }

    public class CreatePurchaseOrderItemDto
    {
        public int? PurchaseId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitCost { get; set; }
    }

    public class UpdatePurchaseOrderItemDto : CreatePurchaseOrderItemDto
    {
        public int Id { get; set; }
    }
}
