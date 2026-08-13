namespace NSW.Core.DTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ContactInfo { get; set; }
        public string? Address { get; set; }
    }

    public class CreateSupplierDto
    {
        public string? Name { get; set; }
        public string? ContactInfo { get; set; }
        public string? Address { get; set; }
    }

    public class UpdateSupplierDto : CreateSupplierDto
    {
        public int Id { get; set; }
    }
}
