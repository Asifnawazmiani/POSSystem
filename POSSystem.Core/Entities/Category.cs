namespace POSSystem.Core.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }   // Self-referencing for nested categories

    // Navigation Properties
    public Category ParentCategory { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
