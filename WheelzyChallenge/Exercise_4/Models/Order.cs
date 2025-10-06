namespace Exercise_4.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int StatusId { get; set; }

    public int CustomerId { get; set; }

    public bool IsActive { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
