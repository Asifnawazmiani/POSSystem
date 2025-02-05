namespace POSSystem.Core.Entities;

public class SaleDetail
{
    public int SaleDetailId { get; set; }
    public Guid SaleId { get; set; }             // Foreign key to Sales
    public int ProductId { get; set; }           // Foreign key to Products
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }

    // Navigation Properties
    public Sale Sale { get; set; }
    public Product Product { get; set; }
}
