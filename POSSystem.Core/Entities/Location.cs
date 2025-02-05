namespace POSSystem.Core.Entities;

public class Location
{
    public int LocationId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    // Navigation Properties
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    public ICollection<Terminal> Terminals { get; set; } = new List<Terminal>();
}
