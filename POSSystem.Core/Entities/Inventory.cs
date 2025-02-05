namespace POSSystem.Core.Entities;

public class Inventory
{
    public int InventoryId { get; set; }
    public int ProductId { get; set; }           // Foreign key to Products
    public int LocationId { get; set; }          // Foreign key to Locations
    public int Quantity { get; set; }
    public int? ReorderThreshold { get; set; }   // Optional threshold for restocking
    public DateTime LastStocked { get; set; }

    // Navigation Properties
    public Product Product { get; set; }
    public Location Location { get; set; }
}