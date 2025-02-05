namespace POSSystem.Core.Entities;

public class Sale
{
    public Guid SaleId { get; set; } = Guid.NewGuid();
    public int TerminalId { get; set; }          // Foreign key to Terminals
    public int EmployeeId { get; set; }          // Foreign key to Employees
    public int? CustomerId { get; set; }         // Optional foreign key to Customers
    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
    public string PaymentMethod { get; set; }    // e.g., "Cash", "Credit", "Mobile"
    public string PaymentStatus { get; set; }    // e.g., "Pending", "Completed", "Refunded"
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public Terminal Terminal { get; set; }
    public Employee Employee { get; set; }
    public Customer Customer { get; set; }
    public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
