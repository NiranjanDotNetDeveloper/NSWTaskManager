namespace NSW.Core.DTOs
{
    public class SalesIssueItemDto
    {
        public int Id { get; set; }
        public int? SalesIssueId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateSalesIssueItemDto
    {
        public int? SalesIssueId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateSalesIssueItemDto : CreateSalesIssueItemDto
    {
        public int Id { get; set; }
    }
}
