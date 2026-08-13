using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class PurchaseOrderItems
    {
        public int Id { get; set; }
        public PurchaseOrders? PurchaseOrders { get; set; }
        public int? PurchaseId { get; set; }
        public Products? Products { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitCost { get; set; }
    }
}
