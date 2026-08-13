using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class StockLevels
    {
        public int Id { get; set; }
        public Products? Products { get; set; }
        public int? ProductId { get; set; }
        public int? WareHouseId { get; set; }
        public Warehouses? Warehouses { get; set; }
        public int? QuantityOnHand { get; set; }

    }
}
