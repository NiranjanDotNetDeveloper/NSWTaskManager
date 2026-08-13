using System;
using System.Collections.Generic;
using System.Text;

namespace NSW.Core.Domain.Entities
{
    public class Categories
    {
        public int CatId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
