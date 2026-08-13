namespace NSW.Core.DTOs
{
    public class CategoryDto
    {
        public int CatId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class CreateCategoryDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateCategoryDto : CreateCategoryDto
    {
        public int CatId { get; set; }
    }
}
