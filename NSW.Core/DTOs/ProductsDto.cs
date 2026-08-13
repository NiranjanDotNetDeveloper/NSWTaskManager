using System;

namespace NSW.Core.DTOs
{
    public class ProductDto
    {
        public int ProdId { get; set; }
        public string? Name { get; set; }
        public Guid? SKU { get; set; }
        public string? BarCode { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReorderLevel { get; set; }
    }

    public class CreateProductDto
    {
        public string? Name { get; set; }
        public Guid? SKU { get; set; }
        public string? BarCode { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReorderLevel { get; set; }
    }

    public class UpdateProductDto : CreateProductDto
    {
        public int ProdId { get; set; }
    }
}
