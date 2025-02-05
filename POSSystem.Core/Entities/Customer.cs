namespace POSSystem.Core.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int LoyaltyPoints { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Property
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
