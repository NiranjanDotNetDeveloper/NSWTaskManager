namespace NSW.Core.DTOs
{
    public class StockLevelDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WareHouseId { get; set; }
        public int QuantityOnHand { get; set; }
    }

    public class CreateStockLevelDto
    {
        public int ProductId { get; set; }
        public int WareHouseId { get; set; }
        public int QuantityOnHand { get; set; }
    }

    public class UpdateStockLevelDto : CreateStockLevelDto
    {
        public int Id { get; set; }
    }
}
