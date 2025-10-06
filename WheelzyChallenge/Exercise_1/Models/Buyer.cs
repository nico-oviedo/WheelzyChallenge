using System;
using System.Collections.Generic;

namespace Exercise_1.Models;

public partial class Buyer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Amount { get; set; }

    public virtual ICollection<CarQuote> CarQuotes { get; set; } = new List<CarQuote>();

    public virtual ICollection<ZipCode> ZipCodes { get; set; } = new List<ZipCode>();
}
