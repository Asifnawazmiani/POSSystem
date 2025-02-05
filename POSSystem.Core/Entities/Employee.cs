namespace POSSystem.Core.Entities;

public class Employee
{
    public int EmployeeId { get; set; }
    public string UserId { get; set; }           // Ties to ASP.NET Identity (NVARCHAR(450))
    public int RoleId { get; set; }              // Foreign key to Roles
    public DateTime HireDate { get; set; }

    // Navigation Properties
    public Role Role { get; set; }
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
