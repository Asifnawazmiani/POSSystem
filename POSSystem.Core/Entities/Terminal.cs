namespace POSSystem.Core.Entities;

public class Terminal
{
    public int TerminalId { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; }          // Foreign key to Locations
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public Location Location { get; set; }
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}