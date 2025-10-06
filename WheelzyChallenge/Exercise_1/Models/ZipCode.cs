using System;
using System.Collections.Generic;

namespace Exercise_1.Models;

public partial class ZipCode
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<Buyer> Buyers { get; set; } = new List<Buyer>();
}
