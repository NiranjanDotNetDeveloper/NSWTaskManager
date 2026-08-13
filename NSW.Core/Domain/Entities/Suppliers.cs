using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class Suppliers
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ContactInfo { get; set; }
        public string? Address { get; set; }
        public ICollection<PurchaseOrders>? PurchaseOrders { get; set; }
    }
}
