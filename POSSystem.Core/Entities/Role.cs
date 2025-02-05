namespace POSSystem.Core.Entities;

public class Role
{
    public int RoleId { get; set; }
    public string Name { get; set; }             // e.g., "Cashier", "Manager"

    // Navigation Property
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
