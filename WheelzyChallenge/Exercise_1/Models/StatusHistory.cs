using System;
using System.Collections.Generic;

namespace Exercise_1.Models;

public partial class StatusHistory
{
    public int CarQuoteId { get; set; }

    public int StatusId { get; set; }

    public DateTime? Date { get; set; }

    public string? ChangedBy { get; set; }

    public virtual CarQuote CarQuote { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
