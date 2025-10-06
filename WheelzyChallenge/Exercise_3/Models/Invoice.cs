namespace Exercise_3.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public decimal Total { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
