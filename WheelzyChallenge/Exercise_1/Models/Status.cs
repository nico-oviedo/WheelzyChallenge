using System;
using System.Collections.Generic;

namespace Exercise_1.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool HasMandatoryDate { get; set; }

    public virtual ICollection<CarQuote> CarQuotes { get; set; } = new List<CarQuote>();

    public virtual ICollection<StatusHistory> StatusHistories { get; set; } = new List<StatusHistory>();
}
