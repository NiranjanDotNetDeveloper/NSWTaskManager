using System;

namespace NSW.Core.DTOs
{
    public class PurchaseOrderDto
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int WareHouseId { get; set; }
        public string? Status { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class CreatePurchaseOrderDto
    {
        public int SupplierId { get; set; }
        public int WareHouseId { get; set; }
        public string? Status { get; set; }
    }

    public class UpdatePurchaseOrderDto : CreatePurchaseOrderDto
    {
        public int Id { get; set; }
    }
}
