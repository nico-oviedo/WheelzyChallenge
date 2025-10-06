using System;
using System.Collections.Generic;

namespace Exercise_1.Models;

public partial class CarQuote
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public int BuyerId { get; set; }

    public int StatusId { get; set; }

    public bool IsCurrent { get; set; }

    public virtual Buyer Buyer { get; set; } = null!;

    public virtual Car Car { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<StatusHistory> StatusHistories { get; set; } = new List<StatusHistory>();
}
